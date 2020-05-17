using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Student.Any())
                {
                    return;
                }

                context.Student.AddRange(
                    new Student()
                    {
                        Id = 1,
                        Age = 22,
                        FirstName = "Masoud",
                        LastName = "Khodadadi",
                        StdNumber = "954421016"
                    },
                    new Student()
                    {
                        Id = 2,
                        Age = 21,
                        FirstName = "Javad",
                        LastName = "Javadi",
                        StdNumber = "954421017"
                    },
                    new Student()
                    {
                        Id = 3,
                        Age = 23,
                        FirstName = "Sirvan",
                        LastName = "Khosravi",
                        StdNumber = "954421018"
                    });

                context.SaveChanges();
            }
        }
    }
}
