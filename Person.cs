namespace HelloWorld
{
    /**
        var person = new Person { Name = "Steve", Age = 23 };
        Console.WriteLine(person.ToString);

        Console.ReadKey();
    */
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Method hiding using 'new' keyword
        public new string ToString => "Person [" + this.Name + ", " + this.Age + "]";
    }
}
