using BlazorApp.Components.Pages.Courses;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace BlazorApp.Services;

public class CourseService
{
    private readonly ApplicationDbContext _context;
    private readonly UserService _userService;

    public CourseService(ApplicationDbContext context, UserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public bool IsCourseSavedToProfile(string userId, string courseId)
    {
        try
        {
            var user = _context.SavedCourses.Any(x => x.UserId == userId && x.CourseId == courseId);
            if (user)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return false;
    }


    public async Task<bool> RemoveCourseFromProfileAsync(string userId, string courseId)
    {
        try
        {
            var savedCourse = await _context.SavedCourses.FirstOrDefaultAsync(x => x.UserId == userId && x.CourseId == courseId);
            if (savedCourse != null)
            {
                _context.SavedCourses.Remove(savedCourse);
                await _context.SaveChangesAsync();

                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false;
    }

    public async Task<bool> SaveCourseToProfile(string userId, string courseId)
    {
        try
        {
            var exists = await Exists(userId, courseId);
            if (!exists)
            {
                var savedCourse = new SavedCourseEntity
                {
                    UserId = userId,
                    CourseId = courseId
                };
                _context.SavedCourses.Add(savedCourse);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false;
    }


    public async Task RemoveAllCoursesFromProfile()
    {
        try
        {
            var user = await _userService.GetUserAsync();
            if (user != null)
            {
                var userId = user.Id;
                var savedCourses = _context.SavedCourses.Where(x => x.UserId == userId);
                if (savedCourses != null)
                {
                    _context.SavedCourses.RemoveRange(savedCourses);
                    await _context.SaveChangesAsync();

                    //courses = null!;
                    //StateHasChanged();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }



    public async Task<bool> Exists(string userId, string courseId)
    {
        try
        {
            return await _context.SavedCourses.AnyAsync(x => x.UserId == userId && x.CourseId == courseId);
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false;

    }
}
