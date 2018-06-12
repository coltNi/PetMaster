using System.Collections.Generic;

namespace PetMasterGroupingProvider.Domain
{
    public class PetByMasterGenderGroup
    {
        public Gender Gender { get; set; }
        public List<string> PetNames { get; set; }

        public PetByMasterGenderGroup(Gender gender, List<string> names)
        {
            Gender = gender;
            PetNames = names;
        }
    }
}
