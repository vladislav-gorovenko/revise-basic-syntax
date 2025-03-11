namespace ReviseBasicSyntax;

public static class OOP
{
    class SingletonEntity
    {
        private static Dictionary<string, SingletonEntity> people = new Dictionary<string, SingletonEntity>();
        private Guid id;
        private string name;

        protected SingletonEntity(string name)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            people[name] = this;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                if (people.ContainsKey(value))
                {
                    throw new InvalidOperationException("Name is already taken.");
                }
                people.Remove(name);
                name = value;
                people[name] = this;
            }
        }

        public static SingletonEntity GetInstance(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is required");
            }

            if (people.ContainsKey(name))
            {
                return people[name];
            }

            return new SingletonEntity(name);
        }
    }
    
    private class Person
    {
        string name;
        int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return name; }
        }
        
        public int Age
        {
            get { return age; }
        }

        public virtual void printName()
        {
            Console.WriteLine("Name: {0}", name);
        }
    }

    private class Student : Person
    {
        private int averageGrade;

        public Student(string name, int age, int averageGrade) : base(name, age)
        {
            this.averageGrade = averageGrade;
        }

        public override string ToString()
        {
            return $"Student name: {this.Name}, age: {this.Age}, grade: {this.averageGrade}";
        }

        public override void printName()
        {
            Console.WriteLine("Name of student: {0}", this.Name);
        }
    }
    
    public static void CreatingSingleton()
    {
        SingletonEntity person1 = SingletonEntity.GetInstance("Vladislav");
        SingletonEntity person2 = SingletonEntity.GetInstance("Zakhar");
        SingletonEntity person3 = SingletonEntity.GetInstance("Vladislav");
        person3.Name = "Nastya";
        
        Console.WriteLine(person1.Name);
        Console.WriteLine($"{person1 == person2}, person1 == person2");
        Console.WriteLine($"{person1 == person3}, person1 == person3");
    }   
    
    public static void Inheritance()
    {
        Person student = new Student("Vladislav", 23, 5);
        Console.WriteLine(student.ToString());
        student.printName();
    }
    
    abstract class AbstractBox
    {
        public abstract int DimensionX { get; set; }
        public abstract int DimensionY { get; set; }
        public abstract int GetShape();
        public abstract void PrintShape();
    }

    class Box : AbstractBox
    {
        public int dimensionX;
        public int dimensionY;
        
        public override int DimensionX { get => dimensionX; set => dimensionX = value; }
        public override int DimensionY { get => dimensionY; set => dimensionY = value; }

        public Box(int dimensionX, int dimensionY)
        {
            this.dimensionX = dimensionX;
            this.dimensionY = dimensionY;
        }
        
        public override int GetShape()
        {
            return DimensionX * DimensionY;
        }
        
        public override void PrintShape()
        {
            Console.WriteLine($"Dimension X = {DimensionX}, Y = {DimensionY}. Shape = {GetShape()}.");
        }
    }

    public static void PracticeBasicClasses()
    {
        string writeText = "Vlad";
        
        File.WriteAllText("filename.txt", writeText);
        string readText = File.ReadAllText("filename.txt");
        
        Console.WriteLine(readText);
    }
}