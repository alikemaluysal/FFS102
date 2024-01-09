using Bogus;
using ExampleMVCProject.Entities;

namespace ExampleMVCProject.Data;

public class DbFaker
{
    public List<Student> FakeStudents(int count)
    {
        string[] classes = { "A", "B", "C" };
        int userId = 1;
        var userFaker = new Faker<Student>()
                            .RuleFor(s => s.Id, f => userId++)
                            .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                            .RuleFor(s => s.LastName, f => f.Name.LastName())
                            .RuleFor(s => s.Email, f => f.Internet.Email())
                            .RuleFor(s => s.Phone, f => f.Phone.PhoneNumber())
                            .RuleFor(s => s.Class, f => f.PickRandom(classes));

        var students = userFaker.Generate(count);

        return students;
    }
}
