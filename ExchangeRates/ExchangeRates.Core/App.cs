using Acr.UserDialogs;
using ExchangeRates.Core.SQLite;
using ExchangeRates.Core.SQLite.Entities;
using ExchangeRates.Core.SQLite.Repositories;
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

            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            Mvx.RegisterType<IRepository<ExchangeRate>>(
                () => new Repository<ExchangeRate>());

            RegisterNavigationServiceAppStart<ViewModels.FirstViewModel>();
        }
    }
}
