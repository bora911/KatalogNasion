namespace Bora.Katalog.UI.ViewModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    using Microsoft.Extensions.DependencyInjection;

    using Prism.Commands;

    using Bora.Katalog.CORE;
    using Bora.Katalog.DAO;
    using Bora.Katalog.INTERFACES;
    using Bora.Katalog.UI.Services;
    using Bora.Katalog.UI.View;

    public class MainViewModel : INotifyPropertyChanged
    {
        private IDataLoader _dataLoader;

        private string filterText;

        private IFormWindowService _formWindowService;

        private IServiceProvider _serviceProvider;

        private IProducer selectedProducer;
        private SeedType selectedSeedType;
        private SeedCaliber selectedSeedCaliber;
        private ValidityTime selectedValidityTime;


        public MainViewModel(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
            _serviceProvider = (App.Current as App).ServiceProvider;
            _formWindowService = _serviceProvider.GetRequiredService<IFormWindowService>();
            Seeds = new ObservableCollection<ISeed>();
            Producers = new ObservableCollection<IProducer>();
            LoadProducers();
            SeedTypes = new ObservableCollection<SeedType>(typeof(SeedType).GetEnumValues().Cast<SeedType>());
            ValidityTimes = new ObservableCollection<ValidityTime>(typeof(ValidityTime).GetEnumValues().Cast<ValidityTime>());
            SeedCalibers = new ObservableCollection<SeedCaliber>(typeof(SeedCaliber).GetEnumValues().Cast<SeedCaliber>());
            PropertyChanged += MainViewModel_PropertyChanged;
            AddSeedCommand = new DelegateCommand(AddSeed);
            RemoveSeedCommand = new DelegateCommand<int?>(RemoveSeed);
            EditSeedCommand = new DelegateCommand<int?>(EditSeed);
            ClearFiltersCommand = new DelegateCommand(ClearFilters);
        }

        private void ClearFilters()
        {
            SelectedSeedCaliber = 0;
            SelectedSeedType = 0;
            SelectedValidityTime = 0;
            SelectedProducer = null;
        }

        private void LoadProducers()
        {
            var producers = _dataLoader.GetProducers();
            Producers.Clear();
            foreach (var producer in producers)
            {
                Producers.Add(producer);
            }
        }

        public ICommand EditSeedCommand { get; set; }
        
        public ICommand AddSeedCommand { get; set; }

        public ICommand RemoveSeedCommand { get; set; }
        public ICommand ClearFiltersCommand { get; set; }


        public ObservableCollection<ISeed> Seeds { get; set; }
        public ObservableCollection<IProducer> Producers { get; set; }
        public ObservableCollection<SeedType> SeedTypes { get; set; }
        public ObservableCollection<SeedCaliber> SeedCalibers { get; set; }
        public ObservableCollection<ValidityTime> ValidityTimes { get; set; }

        public IProducer SelectedProducer
        {
           get => selectedProducer;
            set
            {
                selectedProducer = value;
                OnPropertyChanged();
            }
        }


        public SeedType SelectedSeedType
        {
            get => selectedSeedType;
            set
            {
                selectedSeedType = value;
                OnPropertyChanged();
            }
        }
        public SeedCaliber SelectedSeedCaliber
        {
            get => selectedSeedCaliber;
            set
            {
                selectedSeedCaliber = value;
                OnPropertyChanged();
            }
        }
        public ValidityTime SelectedValidityTime
        {
            get => selectedValidityTime;
            set
            {
                selectedValidityTime = value;
                OnPropertyChanged();
            }
        }

        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                OnPropertyChanged();
            }
        }
        private void RemoveSeed(int? id)
        {
            if (id != null
                && MessageBox.Show(
                    messageBoxText: "Do you really want to remove that seeds?",
                    "Seeds removing",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _dataLoader.RemoveSeed((int)id);
                Load();
            }
        }

        private void EditSeed(int? id)
        {
            var Seed = Seeds.FirstOrDefault(c => c.Id == id);

            if (Seed != null)
            {
                var SeedVm = new SeedFormViewModel(Seed, _dataLoader.GetProducers());
                var wnd = _formWindowService.CreateWindow<SeedFormView>(
                    $"Seed Edit {Seed.Type} {Seed.Caliber} {Seed.ValidityTime}",
                    SeedVm,
                    () =>
                        {
                            _dataLoader.SaveSeeds(Seeds);
                            Load();
                        },
                    SeedVm.CanSave);
                SeedVm.Window = wnd;
                wnd.Show();
            }
            
        }

        private void AddSeed()
        {
            var SeedVm = new SeedFormViewModel(new Seed(), _dataLoader.GetProducers());
            var wnd = _formWindowService.CreateWindow<SeedFormView>(
                "Add seeds",
                SeedVm,
                () =>
                    {
                        _dataLoader.AddSeed(SeedVm.Seed.Seed);
                        Load();
                    },
                SeedVm.CanSave);
            SeedVm.Window = wnd;
            wnd.Show();
        }

        private void MainViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FilterText) || e.PropertyName == nameof(SelectedSeedType) || e.PropertyName == nameof(SelectedSeedCaliber) || e.PropertyName == nameof(SelectedValidityTime) || e.PropertyName == nameof(SelectedProducer))
            {
                Load();
            }
        }

        public void Load()
        {
            var seeds = _dataLoader.GetSeeds(FilterText, SelectedSeedType, SelectedSeedCaliber, SelectedValidityTime, SelectedProducer);
            Seeds.Clear();
            foreach (var seed in seeds)
            {
                Seeds.Add(seed);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}