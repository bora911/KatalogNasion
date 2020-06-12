using Bora.Katalog.CORE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bora.Katalog.INTERFACES
{
    public interface IDataLoader
    {
        IEnumerable<IProducer> GetProducers();
        IEnumerable<ISeed> GetSeeds(string filterText, SeedType selectedSeedType, SeedCaliber selectedSeedCaliber, ValidityTime selectedValidityTime, IProducer selectedProducer);

        void AddSeed(ISeed seed);
        bool RemoveSeed(int id);
        void SaveSeeds(IEnumerable<ISeed> seeds);
    }
}
