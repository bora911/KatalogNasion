using Bora.Katalog.CORE;
using Bora.Katalog.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bora.Katalog.DAO
{
    class DAOMock1 : IDataProvider
    {
        private static int NextSeedId=11;
        private static int NextProducerId=8;
        private static List<IProducer> Producers = new List<IProducer>()
        {
            new Producer() {Id=1, Name="Legutko"},
            new Producer() {Id=2, Name="PlantiCo"},
            new Producer() {Id=3, Name="PNOS"},
            new Producer() {Id=4, Name="Syngenta"},
            new Producer() {Id=5, Name="Florensis"},
            new Producer() {Id=6, Name="Plantpol"},
            new Producer() {Id=7, Name="Seminis"}
        };

        private static List<ISeed> Seeds = new List<ISeed>()
        {
            new Seed() {Id=1, Producer=Producers[0], ValidityTime=ValidityTime.ONE,  ProductionDate= new DateTime(2019,10, 3), ExpirationDate=new DateTime(2020,10, 3), SeedCaliber=SeedCaliber.SMALL, SeedType=SeedType.GERMINATED, Variety="Sonesta", Type="yellow bean"},
            new Seed() {Id=2, Producer=Producers[6], ValidityTime=ValidityTime.TWO,  ProductionDate= new DateTime(2019,12, 3), ExpirationDate=new DateTime(2021,12, 3), SeedCaliber=SeedCaliber.LARGE, SeedType=SeedType.NOT_GERMINATED, Variety="Unidor", Type="yellow bean"},
            new Seed() {Id=3, Producer=Producers[2], ValidityTime=ValidityTime.TWO,  ProductionDate= new DateTime(2018,12, 3), ExpirationDate=new DateTime(2020,12, 3), SeedCaliber=SeedCaliber.MEDIUM, SeedType=SeedType.GERMINATED, Variety="Dior", Type="yellow bean"},
            new Seed() {Id=4, Producer=Producers[3], ValidityTime=ValidityTime.TWO,  ProductionDate= new DateTime(2019,03, 4), ExpirationDate=new DateTime(2021,03, 4), SeedCaliber=SeedCaliber.SMALL, SeedType=SeedType.NOT_GERMINATED, Variety="Ferrari", Type="green bean"},
            new Seed() {Id=5, Producer=Producers[1], ValidityTime=ValidityTime.THREE,  ProductionDate= new DateTime(2019,12, 3), ExpirationDate=new DateTime(2022,12, 3), SeedCaliber=SeedCaliber.MEDIUM, SeedType=SeedType.GERMINATED, Variety="Unidor", Type="yellow bean"},
            new Seed() {Id=6, Producer=Producers[5], ValidityTime=ValidityTime.TWO,  ProductionDate= new DateTime(2019,12, 3), ExpirationDate=new DateTime(2021,12, 3), SeedCaliber=SeedCaliber.LARGE, SeedType=SeedType.GERMINATED, Variety="Monica", Type="flat bean"},
            new Seed() {Id=7, Producer=Producers[6], ValidityTime=ValidityTime.THREE,  ProductionDate= new DateTime(2018,10, 10), ExpirationDate=new DateTime(2021,10, 10), SeedCaliber=SeedCaliber.MEDIUM, SeedType=SeedType.NOT_GERMINATED, Variety="Unidor", Type="yellow bean"},
            new Seed() {Id=8, Producer=Producers[5], ValidityTime=ValidityTime.TWO,  ProductionDate= new DateTime(2010,11, 13), ExpirationDate=new DateTime(2012,11, 13), SeedCaliber=SeedCaliber.LARGE, SeedType=SeedType.GERMINATED, Variety="Gold Saxa", Type="yellow bean"},
            new Seed() {Id=9, Producer=Producers[2], ValidityTime=ValidityTime.ONE,  ProductionDate= new DateTime(2019,11, 1), ExpirationDate=new DateTime(2020,11, 1), SeedCaliber=SeedCaliber.MEDIUM, SeedType=SeedType.GERMINATED, Variety="Unidor", Type="yellow bean"},
            new Seed() {Id=10, Producer=Producers[1], ValidityTime=ValidityTime.THREE,  ProductionDate= new DateTime(2017,12, 30), ExpirationDate=new DateTime(2020,12, 30), SeedCaliber=SeedCaliber.LARGE, SeedType=SeedType.NOT_GERMINATED, Variety="Omica", Type="green bean"}
        };

        public IEnumerable<ISeed> GetSeeds()
        {
            return Seeds;
        }
        public IEnumerable<IProducer> GetProducers()
        {
            return Producers;
        }
        public void SaveSeeds(IEnumerable<ISeed> seeds)
        {
            Seeds.Clear();
            foreach( var s in seeds)
            {
                Seeds.Add(s);
            }
        }
        public void SaveProducers(IEnumerable<IProducer> producers)
        {
            Producers.Clear();
            foreach(var p in producers)
            {
                Producers.Add(p);
            }
        }
        public void AddSeed(ISeed seed)
        {
            seed.Id = NextSeedId++;
            Seeds.Add(seed);
        }
        public void AddProducers(IProducer producer)
        {
            producer.Id = NextProducerId++;
            Producers.Add(producer);
        }
        public bool RemoveSeed(ISeed seed)
        {
            Seeds.Remove(seed);
            return true;
        }
        public bool RemoveProducer(IProducer producer)
        {
            Producers.Remove(producer);
            return true;
        }
        public void EditSeed(ISeed seedOld, ISeed seedNew)
        {
            Seeds.Remove(seedOld);
            Seeds.Add(seedNew);
        }

    }
}
