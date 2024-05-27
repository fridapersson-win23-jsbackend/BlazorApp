using BlazorApp.Data;
using BlazorApp.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;



namespace BlazorApp.Services;

public class UserService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly HttpClient _http;

    public UserService(IServiceScopeFactory scopeFactory, AuthenticationStateProvider authenticationStateProvider, ApplicationDbContext context, UserManager<ApplicationUser> userManager, HttpClient http)
    {
        _scopeFactory = scopeFactory;
        _authenticationStateProvider = authenticationStateProvider;
        _context = context;
        _userManager = userManager;
        _http = http;
    }

    public async Task<ClaimsPrincipal> GetClaimsAsync()
    {
        try
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState != null)
            {
                var user = authState.User;

                if (user != null)
                {
                    return user;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR : EmailSender.Run() :: {ex.Message} ");
        }
        return null!;
    }

    public async Task<ApplicationUser> GetUserAsync()
    {
        try
        {
            var user = await GetClaimsAsync();
            if (user != null)
            {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                if (user != null)
                {
                    var userId = userManager.GetUserId(user);
                    var applicationUser = await context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == userId);
                    return applicationUser!;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        return null!;
    }


    public async Task<bool> UpdateUserAsync(AccountDetailsModel accountDetails)
    {
        try
        {
            var userClaims = await GetClaimsAsync();
            if (userClaims != null)
            {
                using var scope = _scopeFactory.CreateScope();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var userId = userManager.GetUserId(userClaims);
                var user = await userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    user.FirstName = accountDetails.FirstName;
                    user.LastName = accountDetails.LastName;
                    user.PhoneNumber = accountDetails.PhoneNumber;
                    user.Biography = accountDetails.Biography;

                    var existingAddress = await dbContext.Addresses
                        .FirstOrDefaultAsync(x => x.AddressLine_1 == accountDetails.AddressLine_1 &&
                                                  x.AddressLine_2 == accountDetails.AddressLine_2 &&
                                                  x.PostalCode == accountDetails.PostalCode &&
                                                  x.City == accountDetails.City);

                    if (existingAddress != null)
                    {
                        user.AddressId = existingAddress.Id;
                    }
                    else
                    {
                        var newAddress = new AddressEntity
                        {
                            AddressLine_1 = accountDetails.AddressLine_1,
                            AddressLine_2 = accountDetails.AddressLine_2,
                            PostalCode = accountDetails.PostalCode,
                            City = accountDetails.City
                        };

                        //dbContext.Addresses.Add(newAddress);
                        //await dbContext.SaveChangesAsync();

                        //user.AddressId = newAddress.Id;
                    }

                    //var result = await userManager.UpdateAsync(user);
                    //return result.Succeeded;
                }
                else
                {
                    Console.WriteLine("User not found");
                }

                var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var result = await _http.PostAsync()

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: UpdateUserAsync() :: {ex.Message}");
        }
        return false;
    }


    public async Task<List<SavedCourseEntity>> GetAllSavedCourses(ClaimsPrincipal loggedInUser)
    {
        try
        {
            var user = await GetUserAsync();
            if (user != null)
            {
                var savedCoursesIds = await GetSavedCourseIdsForUserAsync(user.Id);
                if (savedCoursesIds != null)
                {
                    var savedCourses = new List<SavedCourseEntity>();

                    foreach (var courseId in savedCoursesIds)
                    {
                        savedCourses.Add(new SavedCourseEntity
                        {
                            UserId = user.Id,
                            CourseId = courseId
                        });
                    }
                    return savedCourses;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return new List<SavedCourseEntity>();
    }

    public async Task<List<string>> GetSavedCourseIdsForUserAsync(string userId)
    {
        try
        {
            var savedCourseIds = await _context.SavedCourses.Where(x => x.UserId == userId).Select(x => x.CourseId).ToListAsync();
            return savedCourseIds;
        }
        catch(Exception ex) { Debug.WriteLine(ex.Message); }
        return [];
    }

}
