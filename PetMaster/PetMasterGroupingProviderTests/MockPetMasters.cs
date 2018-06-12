using System.Collections.Generic;
using PetMasterGroupingProvider.Domain;

namespace PetMasterGroupingProvider.Tests
{
    public static class MockPetMasters
    {
        private static Domain.PetMaster _mock1 = new Domain.PetMaster("Mock1", 35, Gender.Male);
        private static Domain.PetMaster _mock2 = new Domain.PetMaster("Mock2", 32, Gender.Male);
        private static Domain.PetMaster _mock3 = new Domain.PetMaster("Mock3", 13, Gender.Female);
        private static Domain.PetMaster _mock4 = new Domain.PetMaster("Mock4", 44, Gender.Female);
        private static Domain.PetMaster _mock5 = new Domain.PetMaster("Mock5", 44, Gender.Female);

        public static void PetSetUp()
        {
            _mock1.Pets = new List<PetBase>()
            {
                new Pet("abcd", "cat"),
                new Pet("abcq", "cat"),
            };

            _mock2.Pets = new List<PetBase>()
            {
                new Pet("zz", "dog"),
                new Pet("abce", "cat"),
            };

            _mock3.Pets = new List<PetBase>()
            {
                new Pet("ab", "cat"),
            };
            _mock4.Pets = new List<PetBase>()
            {
            };
            _mock5.Pets = new List<PetBase>()
            {
                new Pet("ab", "cat"),
            };
        }

        public static List<Domain.PetMaster> GetPetMasters()
        {
            PetSetUp();
            return new List<Domain.PetMaster>
            {
                _mock1,
                _mock2,
                _mock3,
                _mock4,
                _mock5
            };
        }
    }
}
