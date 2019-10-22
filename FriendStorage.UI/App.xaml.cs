using System.Windows;
using Autofac;
using FriendStorage.UI.Startup;
using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI
{
    public partial class App : Application
    {
        private MainViewModel _mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Bootstrapper bootstrapper = new Bootstrapper();
            IContainer container = Bootstrapper.Bootstrap();

            _mainViewModel = container.Resolve<MainViewModel>();
            MainWindow = new MainWindow(_mainViewModel);
            MainWindow.Show();
            _mainViewModel.Load();
        }
    }
}
