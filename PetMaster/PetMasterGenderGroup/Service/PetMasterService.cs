using System.Collections.Generic;
using System.Linq;
using PetMasterGroupingProvider.Domain;
using PetMasterGroupingProvider.Repository;

namespace PetMasterGroupingProvider.Service
{
    public interface IPetMasterService
    {
        List<PetByMasterGenderGroup> GetAscendingNameForTypeGroupByMasterGender(string type);
    }
    public class PetMasterService : IPetMasterService
    {
        private readonly IPetMasterRepository _petMasterRepo;

        public PetMasterService(IPetMasterRepository petMasterRepo)
        {
            _petMasterRepo = petMasterRepo;
        }

        public List<PetByMasterGenderGroup> GetAscendingNameForTypeGroupByMasterGender(string type)
        {
            var petMasters = _petMasterRepo.GetMastersWithPets();
            var result = new List<PetByMasterGenderGroup>();
            var genders = petMasters.Select(s => s.Gender).Distinct();
            foreach (var gender in genders)
            {
                var names = GetPetNamesByGenderAndType(gender, type, petMasters);
                if (names.Count > 0)
                {
                    result.Add(new PetByMasterGenderGroup(gender, names.OrderBy(t => t).ToList()));
                }      
            }
            return result;
        }

        private List<string> GetPetNamesByGenderAndType(Gender gender, string type, List<Domain.PetMaster> petMasters)
        {
            var masters = petMasters.Where(s => s.Gender == gender);
            var names = new List<string>();
            foreach (var master in masters)
            {
                names.AddRange(master.Pets.Where(t => t.Type.ToLower().Equals(type.ToLower())).Select(p => p.Name));
            }
            return names;
        }
    }
}
