using Android.OS;
using Android.Support.V7.Widget;
using ExchangeRates.Core.SQLite;
using ExchangeRates.Droid.Services;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;

namespace ExchangeRates.Droid.Views
{
    public abstract class BaseView : MvxAppCompatActivity
    {
        protected Toolbar Toolbar { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(LayoutResource);

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }

            Mvx.RegisterSingleton<ISQLite>(new SQLiteAndroid());
        }

        protected abstract int LayoutResource { get; }
    }
}
