using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using web;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var people = new List<Person>();

app.MapGet("/", () => "Hello World!");

app.MapPost("/p", () =>
{
    var peopleJson = File.ReadAllText("people.json");
    people.AddRange(JsonSerializer.Deserialize<IEnumerable<Person>>(peopleJson));
    return Task.FromResult(JsonSerializer.Serialize(people));
});

app.MapGet("/people", () => JsonSerializer.Serialize(people));

app.MapGet("/person/{id}", (int id) =>
{
    var person = people.FirstOrDefault(p => p.Id == id);
    
    // return JsonSerializer.Serialize(person);
    return $"Hello {person.Name} ({person.Id}, {person.Age})";
});

app.MapPost("/person", ([FromBody] Person person) =>
{
    // var person = JsonSerializer.Deserialize<Person>(jsonStr);

    switch (person)
    {
        case Student student when student.School == "katta":
            Console.WriteLine("KATTA!");
            break;
        case Student student:
            Console.WriteLine($"Goes to {student.School}");
            break;
    }
    people.Add(person);

    return JsonSerializer.Serialize(people);
});



// app.MapGet("/tuple", () =>
// {
//     (id, name, age) = GetPerson();
//     return $"";
// });

// Person GetPerson()
// {
//     var person = new Person
//     {
//         Id = 1,
//         Name = "Trym",
//         Age = 27
//     };
//     // var age = (num: 27, year: 1995);
//     return person;
// }

app.Run();


record Vehicle(string Make, string Color);

record Car(string Make, string Color, Tire tire) : Vehicle(Make, Color);

record Tire(int size, int width);