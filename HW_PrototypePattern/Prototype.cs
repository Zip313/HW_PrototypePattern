namespace HW_PrototypePattern
{
    public class Prototype : IPattern
    {
        public void Execute()
        {
            Doberman doberman1 = new Doberman(5);
            Animal doberman2 = doberman1.MyClone();
            Doberman doberman3 = (Doberman)doberman2.Clone();
            doberman2.WhoAmI();
            doberman3.WhoAmI();

            Shark shark1 = new Shark(5);
            Shark shark2 = shark1.MyClone();
            shark2.WhoAmI();

            Eagl eagl1 = new Eagl(5);
            Eagl eagl2 = eagl1.MyClone();
            eagl2.WhoAmI();
        }
    }


    interface IMyClonable<T>
    {
        T MyClone();
    }


    public abstract class Animal : ICloneable
    {
        private string Name { get; set; }
        protected int Age { get; set; }

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public void WhoAmI()
        {
            Console.WriteLine($"Can i go? - {CanIGo()}");
            Console.WriteLine($"Can i fly? - {CanIFly()}");
            Console.WriteLine($"Can i jump? - {CanISwim()}");
            Console.WriteLine($"I'm {GetName()}");
            Console.WriteLine($"I'm {GetAge()} years old");
            Console.WriteLine();
        }

        public abstract bool CanIGo();
        public abstract bool CanIFly();
        public abstract bool CanISwim();
        public string GetName() => Name;
        public int GetAge() => Age;

        public abstract object Clone();
    }

    public class Dog : Animal
    {
        public Dog(int age) : base("Dog", age) { }
        public override bool CanIFly() => false;
        public override bool CanIGo() => true;
        public override bool CanISwim() => false;
        public override object Clone() => new Dog(Age);

    }
    public class Fish : Animal
    {
        public Fish(int age) : base("Fish", age) { }
        public override bool CanIFly() => false;
        public override bool CanIGo() => false;
        public override bool CanISwim() => true;
        public override object Clone() => new Fish(Age);
    }
    public class Bird : Animal
    {
        public Bird(int age) : base("Bird", age) { }
        public override bool CanIFly() => true;
        public override bool CanIGo() => true;
        public override bool CanISwim() => false;
        public override object Clone() => new Bird(Age);
    }

    public class Doberman : Dog, IMyClonable<Doberman>
    {
        public Doberman(int age) : base(age) { }

        public Doberman MyClone() => new Doberman(Age);
        public override object Clone() => MyClone();

    }

    public class Shark : Fish, IMyClonable<Shark>
    {
        public Shark(int age) : base(age) { }
        public Shark MyClone() => new Shark(Age);
        public override object Clone() => MyClone();
    }

    public class Eagl : Bird, IMyClonable<Eagl>
    {
        public Eagl(int age) : base(age) { }
        public Eagl MyClone() => new Eagl(Age);
        public override object Clone() => MyClone();
    }
}
