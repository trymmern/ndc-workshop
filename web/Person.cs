namespace web;

public class Person {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    
    // public Person(string name, int age)
    // {
    //     Name = name;
    //     Age = age;
    // }

    public void Deconstruct(out int id, out string name, out int age)
    {
        id = Id;
        name = Name;
        age = Age;
    }
}

