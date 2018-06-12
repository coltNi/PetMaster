using System.Linq;
using Moq;
using PetMasterGroupingProvider.Domain;
using PetMasterGroupingProvider.Repository;
using PetMasterGroupingProvider.Service;
using Xunit;

namespace PetMasterGroupingProvider.Tests
{
    public class GenderGroupingTests
    {
        [Fact]
        public void GetPetNameAscByGenderTest()
        {
            var getPetMastersRepoMock = new Mock<IPetMasterRepository>();
            getPetMastersRepoMock.Setup(s => s.GetMastersWithPets()).Returns(MockPetMasters.GetPetMasters);

            var service = new PetMasterService(getPetMastersRepoMock.Object);

            var result = service.GetAscendingNameForTypeGroupByMasterGender("cat");

            Assert.Equal(2, result.Count);
            var maleList = result.Where(s => s.Gender == Gender.Male).ToList();
            Assert.Single(maleList);

            var catsForMale = maleList[0].PetNames;
            Assert.Equal(3, catsForMale.Count);

            Assert.Equal("abcd", catsForMale[0]);
            Assert.Equal("abce", catsForMale[1]);
            Assert.Equal("abcq", catsForMale[2]);


            var femaleList = result.Where(s => s.Gender == Gender.Female).ToList();
            Assert.Single(femaleList);

            var catsForFemale = femaleList[0].PetNames;
            Assert.Equal(2, catsForFemale.Count);
            Assert.Equal("ab", catsForFemale[0]);
            Assert.Equal("ab", catsForFemale[1]);
        }
    }
}
