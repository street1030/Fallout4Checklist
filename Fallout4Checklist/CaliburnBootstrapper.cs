using Caliburn.Micro;
using Fallout4Checklist.ViewModels;

namespace Fallout4Checklist
{
    public class CaliburnBootstrapper : BootstrapperBase
    {
        public CaliburnBootstrapper()
        {
            Initialize();
        }

        public static IEventAggregator EventAggregator = new EventAggregator();

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
