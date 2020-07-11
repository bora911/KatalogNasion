namespace Bora.Katalog.UI.ViewModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;

    using Prism.Commands;

    using Bora.Katalog.BL;
    using Bora.Katalog.CORE;
    using Bora.Katalog.INTERFACES;

    class SeedFormViewModel
    {
        public SeedFormViewModel(ISeed seed, IEnumerable<IProducer> producers)
        {
            Seed = new SeedWrapper(seed);
            Producers = producers;
            SeedTypes = typeof(SeedType).GetEnumValues();
            SeedCalibers = typeof(SeedCaliber).GetEnumValues();
            ValidityTimes = typeof(ValidityTime).GetEnumValues();
            Seed.PropertyChanged += Seed_PropertyChanged;
        }

        private void Seed_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Seed.HasErrors))
            {
                (Window.ZapiszButton.Command as DelegateCommand)?.RaiseCanExecuteChanged();
            }
        }

        public IEnumerable SeedTypes { get; set; }
        public IEnumerable SeedCalibers { get; set; }

        public IEnumerable ValidityTimes { get; }

        public IEnumerable<IProducer> Producers { get; set; }

        public SeedWrapper Seed { get; set; }

        public bool CanSave() => !Seed.HasErrors;

        public FormWindow Window { get; set; }
    }
}
