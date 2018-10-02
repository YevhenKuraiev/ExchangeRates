using Acr.UserDialogs;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace ExchangeRates.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<ViewModels.FirstViewModel>();
            //RegisterNavigationServiceAppStart<ViewModels.DetailViewModel>();
            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
        }
    }
}
