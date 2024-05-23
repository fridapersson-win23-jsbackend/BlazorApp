using BlazorApp.Data;
using BlazorApp.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorApp.Services;

public class UserService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(IServiceScopeFactory scopeFactory, AuthenticationStateProvider authenticationStateProvider, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _scopeFactory = scopeFactory;
        _authenticationStateProvider = authenticationStateProvider;
        _context = context;
        _userManager = userManager;
    }

    public async Task<ClaimsPrincipal> GetClaimsAsync()
    {
        try
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if(authState != null)
            {
                var user = authState.User;

                if(user != null)
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
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user != null)
            {
                var userId = userManager.GetUserId(user);
                var appUser = await context.Users
                                           .Include(u => u.Address) 
                                           .FirstOrDefaultAsync(u => u.Id == userId);
                return appUser!;
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
            using var scope = _scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


            if (userManager != null)
            {
                var user = await userManager.FindByEmailAsync(accountDetails.Email);
                if (user != null)
                {
                    user.FirstName = accountDetails.FirstName;
                    user.LastName = accountDetails.LastName;
                    user.PhoneNumber = accountDetails.PhoneNumber;
                    user.Biography = accountDetails.Biography;

                    
                    var existingAddress = await dbContext.Addresses
                        .FirstOrDefaultAsync(a => a.AddressLine_1 == accountDetails.AddressLine_1 &&
                                                  a.AddressLine_2 == accountDetails.AddressLine_2 &&
                                                  a.PostalCode == accountDetails.PostalCode &&
                                                  a.City == accountDetails.City);

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

                        dbContext.Addresses.Add(newAddress);
                        await dbContext.SaveChangesAsync();

                        user.AddressId = newAddress.Id;
                    }

                    var result = await userManager.UpdateAsync(user);
                    return result.Succeeded;
                }
                else
                {
                    Console.WriteLine("User not found");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        return false;
    }
}
