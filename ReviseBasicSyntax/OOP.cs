namespace ReviseBasicSyntax;

public static class OOP
{
    class SingletonPerson
    {
        private static Dictionary<string, SingletonPerson> people = new Dictionary<string, SingletonPerson>();
        private Guid id;
        private string name;

        private SingletonPerson(string name)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            people[name] = this;
        }

        public static SingletonPerson GetInstance(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is required");
            }

            if (people.ContainsKey(name))
            {
                return people[name];
            }

            return new SingletonPerson(name);
        }
    }

    public static void CreatingSingleton()
    {
        SingletonPerson person1 = SingletonPerson.GetInstance("Vladislav");
        SingletonPerson person2 = SingletonPerson.GetInstance("Zakhar");
        SingletonPerson person3 = SingletonPerson.GetInstance("Vladislav");
        Console.WriteLine($"{person1 == person2}, person1 == person2");
        Console.WriteLine($"{person1 == person3}, person1 == person3");
    }
}