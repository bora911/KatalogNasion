using System;

namespace Bora.Katalog.UI.Services
{
    using System.Windows.Controls;

    using Prism.Commands;

    using Bora.Katalog.UI.ViewModel;

    public class FormWindowService : IFormWindowService
    {
        public FormWindow CreateWindow<TView>(string title, object viewModel, Action save, Func<bool> canSave) where TView : UserControl, new()
        {
            var formWnd = new FormWindow() {Title = title};
            var formView = new TView { DataContext = viewModel };
            formWnd.Grid.Children.Add(formView);
            formWnd.AnulujButton.Command = new DelegateCommand(() => formWnd.Close());
            formWnd.ZapiszButton.Command = new DelegateCommand(() => { save(); formWnd.Close(); }, canSave);
            return formWnd;
        }


    }
}
