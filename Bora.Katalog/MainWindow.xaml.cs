using System.Windows;

namespace Bora.Katalog.UI
{
    using Bora.Katalog.UI.View;
    using Bora.Katalog.UI.ViewModel;


    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            Content = new MainView() {DataContext = viewModel};

        }
    }
}
