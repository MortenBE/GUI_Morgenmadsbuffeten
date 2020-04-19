using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Morgenmadsbuffeten.Data;

namespace Morgenmadsbuffeten.Data
{
    public class DbHelper
    {

        public static void SeedData(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {
            SeedKitchen(userManager, log);
            SeedReception(userManager, log);
            SeedWaiter(userManager, log);
        }


        public static void SeedKitchen(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string KitchenAdminEmail = "Kitchen@staff.com";
            const string KitchenAdminPassword = "Iamstaff69!";

            if (userManager.FindByNameAsync(KitchenAdminEmail).Result == null)
            {
                log.LogWarning("Seeding kitchen user");
                var user = new IdentityUser
                {
                    UserName = KitchenAdminEmail,
                    Email = KitchenAdminEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, KitchenAdminPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("KitchenStaff", "Yes");
                    var adminClaimResult = userManager.AddClaimAsync(user, adminClaim);
                    adminClaimResult.Wait();
                }
            }
        }

        public static void SeedReception(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string adminEmail = "Reception@staff.dk";
            const string adminPassword = "Iamstaff1!";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                log.LogWarning("Seeding Reception user");
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("ReceptionStaff", "Yes");
                    var adminClaimResult = userManager.AddClaimAsync(user, adminClaim);
                    adminClaimResult.Wait();
                }
            }
        }

        public static void SeedWaiter(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string adminEmail = "Waiter@staff.dk";
            const string adminPassword = "Iamstaff1!";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                log.LogWarning("Seeding waiter user");
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("WaiterStaff", "Yes");
                    var adminClaimResult = userManager.AddClaimAsync(user, adminClaim);
                    adminClaimResult.Wait();
                }
            }
        }
    }
}