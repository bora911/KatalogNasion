using System;
using System.Collections.Generic;
using System.Text;

namespace Bora.Katalog.INTERFACES
{
    public interface IDataProvider
    {
        IEnumerable<ISeed> GetSeeds();

        IEnumerable<IProducer> GetProducers();

        void SaveSeeds(IEnumerable<ISeed> seeds);

        void SaveProducers(IEnumerable<IProducer> producers);

        void AddSeed(ISeed seed);

        void AddProducers(IProducer producer);

        bool RemoveSeed(ISeed seed);

        bool RemoveProducer(IProducer producer);
    }
}
