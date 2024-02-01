using Microsoft.AspNetCore.Identity;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;

namespace PhoneEcommerce.Repository
{
    public class Seed
    {
        public static async Task SeedData(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<RegisterDto>
                {
                    new RegisterDto
                    {
                        Email = "bob@test.com",
                        Password = "Pa$$w0rd",
                        DisplayName = "Bob",
                        UserName = "bob",
                        FirstName = "Bob",
                        LastName = "Smith",
                        Address = "123 Main Street, Cityville, State",
                        PostalCode = "12345"
                    },
                    new RegisterDto
                    {
                        Email = "jane@test.com",
                        Password = "Pa$$w0rd",
                        DisplayName = "Jane",
                        UserName = "jane",
                        FirstName = "Jane",
                        LastName = "Doe",
                        Address = "456 Oak Avenue, Townsville, State",
                        PostalCode = "67890"
                    },
                    new RegisterDto
                    {
                        Email = "tom@test.com",
                        Password = "Pa$$w0rd",
                        DisplayName = "Tom",
                        UserName = "tom",
                        FirstName = "Tom",
                        LastName = "Johnson",
                        Address = "Tom's Address",
                        PostalCode = "789 Pine Street, Villageland, State"
                    },
                };

                foreach (var userDto in users)
                {
                    var user = new AppUser
                    {
                        DisplayName = userDto.DisplayName,
                        UserName = userDto.UserName,
                        Email = userDto.Email
                    };

                    await userManager.CreateAsync(user, userDto.Password);

                    // Her bir kullanıcı için bir Customer oluştur
                    var customer = new Customer
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Address = userDto.Address,
                        PostalCode = userDto.PostalCode,
                        AppUserId = user.Id
                    };

                    // Customer'ı veritabanına ekle
                    context.Customers.Add(customer);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}