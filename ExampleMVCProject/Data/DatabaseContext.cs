using Bogus;
using ExampleMVCProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleMVCProject.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //string[] classes = {"A",  "B", "C"};
        //int userId = 1;
        //var userFaker = new Faker<Student>()
        //                    .RuleFor(s => s.Id, f => userId++)
        //                    .RuleFor(s => s.FirstName, f => f.Name.FirstName())
        //                    .RuleFor(s => s.LastName, f => f.Name.LastName())
        //                    .RuleFor(s => s.Email, f => f.Internet.Email())
        //                    .RuleFor(s => s.Phone, f => f.Phone.PhoneNumber())
        //                    .RuleFor(s => s.Class, f => f.PickRandom(classes));

        //var students = userFaker.Generate(50);

        DbFaker faker = new DbFaker();

        var students = faker.FakeStudents(20);


        modelBuilder.Entity<Student>().HasData(students);
    }


}
