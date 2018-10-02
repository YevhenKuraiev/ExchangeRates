using Android.App;
using Android.OS;

namespace ExchangeRates.Droid.Views
{
    [Activity(Label = "View for DetailView")]
    public class DetailView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.DetailView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}