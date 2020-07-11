using Bora.Katalog.CORE;
using Bora.Katalog.INTERFACES;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Bora.Katalog.BL
{
    public class SeedWrapper:BaseWrapper
    {

        public ISeed Seed { get; set; }

        public SeedWrapper(ISeed seed)
        {
            Seed = seed;
            variety = seed.Variety;
            type = seed.Type;
            expirationDate = seed.ExpirationDate;
            productionDate = seed.ProductionDate;
            producer = seed.Producer;
            seedType = seed.SeedType;
            seedCaliber = seed.SeedCaliber;
            validityTime = seed.ValidityTime;

            foreach (var property in typeof(SeedWrapper).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                ValidateDataAnnotation(property.GetValue(this), property.Name);
            }
        }

        private string variety;

        [Required]
        public string Variety
        {
            get => variety;
            set
            {
                variety = value;
                if (ValidateDataAnnotation(value))
                {
                    Seed.Variety = value;
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }
        private string type;

        [Required]
        public string Type
        {
            get => type;
            set
            {
                type = value;
                if (ValidateDataAnnotation(value))
                {
                    Seed.Type = value;
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }


        private ValidityTime validityTime;
        [Required]
        public ValidityTime ValidityTime
        {
            get => validityTime;
            set
            {
                validityTime = value;
                if (ValidateDataAnnotation(value))
                {
                    Seed.ValidityTime = value;
                    Seed.ExpirationDate = Seed.ProductionDate.AddYears((int)validityTime);
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }




        private DateTime productionDate;

        [Required]
        public DateTime ProductionDate
        {
            get => productionDate;
            set
            {
                
                productionDate = value;
                if (ValidateDataAnnotation(value))
                {
                    Seed.ProductionDate = value;
                    Seed.ExpirationDate = Seed.ProductionDate.AddYears((int)validityTime);
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }


        private DateTime expirationDate;
        [Required]
        public DateTime ExpirationDate
        {
            get => expirationDate;
            set
            {
                expirationDate = value;
                if (ValidateDataAnnotation(value))
                {
                    Seed.ExpirationDate = value;
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }

        private IProducer producer;
        [Required]
        public IProducer Producer
        {
            get => producer;
            set
            {
                producer = value;
                if (ValidateDataAnnotation(value))
                {
                    Seed.Producer = value;
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }


        private SeedType seedType;
        [Required]
        public SeedType SeedType
        {
            get => seedType;
            set
            {
                seedType = value;
                if (ValidateDataAnnotation(value))
                {
                    Seed.SeedType = value;
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }

        private SeedCaliber seedCaliber;
        [Required]
        public SeedCaliber SeedCaliber
        {
            get => seedCaliber;
            set
            {
                seedCaliber = value;
                if (ValidateDataAnnotation(value))
                {
                    Seed.SeedCaliber = value;
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }


    }
}
