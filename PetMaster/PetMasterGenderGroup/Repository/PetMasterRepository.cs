using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using PetMaster.Common;
using PetMaster.Config;
using PetMasterGroupingProvider.Domain;
using PetMasterGroupingProvider.Dto;

namespace PetMasterGroupingProvider.Repository
{
    public interface IPetMasterRepository
    {
        List<Domain.PetMaster> GetMastersWithPets();
    }

    public class PetMasterRepository : IPetMasterRepository
    {
        private readonly string _petMasterSourceUrl;

        public PetMasterRepository(IOptions<ApiConfigs> apiConfigs)
        {
            _petMasterSourceUrl = apiConfigs.Value.PetMasterSourceUrl;
        }

        public List<Domain.PetMaster> GetMastersWithPets()
        {
            var rest = new RestClient<List<PetMasterDto>>();
            var result = rest.Get(_petMasterSourceUrl);
            return result.Select(MapToDomain).ToList();
        }

        private Domain.PetMaster MapToDomain(PetMasterDto dto)
        {
            var result = new Domain.PetMaster(dto.Name, dto.Age, dto.Gender);
            if (dto.Pets != null)
            {
                foreach (var pet in dto.Pets)
                {
                    result.Pets.Add(new Pet(pet.Name, pet.Type));
                }
            }
            return result;
        }
    }
}
