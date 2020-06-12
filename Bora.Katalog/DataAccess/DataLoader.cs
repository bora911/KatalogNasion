using System;
using System.Collections.Generic;
using System.Text;

namespace Bora.Katalog.UI.DataAccess
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Options;

    using Bora.Katalog.CORE;
    using Bora.Katalog.INTERFACES;
    using Bora.Katalog.UI;

    public class DataLoader : IDataLoader
    {
        private AppSettings _settings;

        private Assembly _assembly;

        private IDataProvider _dataProvider;

        public DataLoader(IOptions<AppSettings> options)
        {
            _settings = options.Value;
            _assembly = Assembly.UnsafeLoadFrom(_settings.SeedsLibrary);
            var type = _assembly.GetTypes().SingleOrDefault(t => typeof(IDataProvider).IsAssignableFrom(t));
            if(type != null)
            {
                _dataProvider = Activator.CreateInstance(type) as IDataProvider;
            }
        }

        public IEnumerable<ISeed> GetSeeds(string filterText, SeedType seedType, SeedCaliber seedCaliber, ValidityTime validityTime, IProducer producer)
        {
            var result = _dataProvider.GetSeeds().Where(c => c.Contains(filterText));
            
            if(seedType != 0)
            {
                result = result.Where(c => c.SeedType == seedType);
            }
            if (producer != null)
            {
                result = result.Where(c => c.Producer == producer);
            }
            if ( seedCaliber != 0)
            {
                result = result.Where(c => c.SeedCaliber == seedCaliber);              
            }
            if (validityTime != 0)
            {
                result = result.Where(c => c.ValidityTime == validityTime);
            }
            return result;
        }

        public IEnumerable<IProducer> GetProducers()
        {
            return _dataProvider.GetProducers().ToList();
        }

        public void AddSeed(ISeed seed)
        {
            _dataProvider.AddSeed(seed);
        }

        public void SaveSeeds(IEnumerable<ISeed> seeds)
        {
            _dataProvider.SaveSeeds(seeds);
        }
        public bool RemoveSeed(int id)
        {
            var seed = _dataProvider.GetSeeds().FirstOrDefault(c => c.Id == id);
            if (seed == null) return false;
            return _dataProvider.RemoveSeed(seed);
        }
    }
}
