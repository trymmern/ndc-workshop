namespace console;
class Program
{
    record Vehicle(string Make, string Color) : IVehecle;

    record Car(string Make, string Color, Tire tire) : Vehicle(Make, Color);

    record Tire(int size, int width);
    
    static void Main(string[] args)
    {
        var vehicle = new Car("Honda", "Red", new Tire(45, 13));
        var x = ("Yamaha", "Green");

        var result = vehicle switch
        {
            Car ( Make: "Honda", Color: "Red") => $"This is a Red Honda",
            Car { Make: "Honda", tire.size: 45 } car => $"This is a {car.Make} with tire size {car.tire.size}",
        };

        var res = x switch
        {
            (_, "Red") => "nah",
            (_, "Green") => "yes"
        };
        
        
        Console.WriteLine(result);
        Console.WriteLine(res);
    }
}

interface IVehecle
{
}