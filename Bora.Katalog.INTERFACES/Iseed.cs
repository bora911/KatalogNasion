using Bora.Katalog.CORE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bora.Katalog.INTERFACES
{
    public interface ISeed
    {
         int Id { get; set; }
         string Variety { get; set; }

         string Type { get; set; }

        string Caliber { get; set; }

        string Validity { get; set; }
        DateTime ExpirationDate { get; set; }

         DateTime ProductionDate { get; set; }

         IProducer Producer { get; set; }

         SeedType SeedType { get; set; }

         SeedCaliber SeedCaliber { get; set; }

         ValidityTime ValidityTime { get; set; }

        bool Contains(string filterText);
    }
}
