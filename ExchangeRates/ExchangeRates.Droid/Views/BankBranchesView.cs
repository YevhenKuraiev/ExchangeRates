
using Android.App;
using Android.OS;

namespace ExchangeRates.Droid.Views
{
    [Activity(Label = "View for BankBranchesView")]
    class BankBranchesView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.BankBranchesView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}