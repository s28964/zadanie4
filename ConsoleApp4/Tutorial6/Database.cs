using Tutorial6.Models;

namespace Tutorial6;

public static class Database
{
    public static List<Animal> Animals { get; } = new List<Animal>
    {
        new Animal {ID = 1, Name = "Doggo", Category = "Dog", Weight = 18.5f, FurColor = "Black"},
        new Animal {ID = 2, Name = "Kitty", Category = "Cat", Weight = 4.5f, FurColor = "Gray"},
        new Animal {ID = 3, Name = "Jumpiboy", Category = "rabbit", Weight = 7.5f, FurColor = "White"},
    };

    public static List<Visit> Visits { get; } = new List<Visit>
    {
        new Visit { AnimalID = 1, Date = DateTime.Now.AddDays(3), Description = "some reason", Price = 150 },
        new Visit { AnimalID = 2, Date = DateTime.Now.AddDays(-6), Description = "some reason2", Price = 120 },
        new Visit { AnimalID = 3, Date = DateTime.Now.AddDays(1), Description = "some reason3", Price = 210 },
    };
}