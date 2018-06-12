namespace PetMasterGroupingProvider.Domain
{
    public abstract class PetBase
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Pet : PetBase
    {
        public Pet(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

/* A different design of Pet
    public abstract class PetBase2
    {
        public string Name { get; set; }
        public abstract string Type { get;}
    }

    public class Cat : PetBase2
    {
        public override string Type => "Cat";
    }

    public class Dog : PetBase2
    {
        public override string Type => "Dog";
    }

    public class Fish : PetBase2
    {
        public override string Type => "Fish";
    }
*/
}
