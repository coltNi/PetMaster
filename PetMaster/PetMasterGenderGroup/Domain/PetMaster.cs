using System.Collections.Generic;

namespace PetMasterGroupingProvider.Domain
{
    public class PetMaster
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public List<PetBase> Pets { get; set; } = new List<PetBase>();

        public PetMaster(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
    }
}
