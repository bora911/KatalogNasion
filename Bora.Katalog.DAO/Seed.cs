using Bora.Katalog.CORE;
using Bora.Katalog.INTERFACES;
using System;

namespace Bora.Katalog.DAO
{
    public class Seed : ISeed
    {
        public int Id { get; set; }
        public string Variety { get; set; }
        
        public string Type { get; set; }

        public string Caliber { get; set; }

        public string Validity { get; set; }
        public DateTime ExpirationDate { get; set; }

        public DateTime ProductionDate { get; set; }
        
        public IProducer Producer { get; set; }

        public SeedType SeedType { get; set; }

        public SeedCaliber SeedCaliber { get; set; }

        public ValidityTime ValidityTime { get; set; }

        private string SearchField => Producer + Type + Variety ;
        public bool Contains(string filterText)
        {
            return SearchField.ToLower().Replace(" ", string.Empty).Contains(filterText.ToLower().Replace(" ", string.Empty));
        }


    }
}
