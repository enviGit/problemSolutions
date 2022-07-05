using System;

namespace Dziedziczenie
{
    public class Person
    {
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string familyName, int age)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
        }
        public void modifyFirstName(string newFirstName)
        {
            FirstName = newFirstName;
        }
        public void modifyFamilyName(string newFamilyName)
        {
            FamilyName = newFamilyName;
        }
        public void modifyAge(int newAge)
        {
            Age = newAge;
        }
        public void print()
        {
            Console.WriteLine($"{FirstName} {FamilyName} ({Age})");
        }
    }
    public class Child : Person
    {
        public Child(string firstName, string familyName, int age/*, Person mother, Person father*/) : base(firstName, familyName, age)
        {
        }
        public string mother { get; set; }
        public string father { get; set; }

        public new void print()
        {
            Console.WriteLine($"{FirstName} {FamilyName} ({Age})");
            Console.WriteLine($"mother: {FirstName} {FamilyName} ({Age})");
            Console.WriteLine($"father: {FirstName} {FamilyName} ({Age})");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person o = new Person(familyName: "Molenda", firstName: "Krzysztof", age: 30);
                Person m = new Person(familyName: "Molenda", firstName: "Ewa", age: 29);
                Child d = new Child(familyName: "Molenda", firstName: "Anna", age: 10/*,
                                    mother: m, father: o*/);
                Console.WriteLine(d);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
