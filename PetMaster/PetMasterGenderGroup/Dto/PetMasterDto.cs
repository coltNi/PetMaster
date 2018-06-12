using System.Collections.Generic;
using PetMasterGroupingProvider.Domain;

namespace PetMasterGroupingProvider.Dto
{
    public class PetMasterDto
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        public List<PetDto> Pets { get; set; } = new List<PetDto>();
    }
}
