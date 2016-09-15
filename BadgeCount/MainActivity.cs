using Android.App;
using Android.OS;
using Android.Widget;
using BadgeCount.BadgeCount;

namespace BadgeCount
{
    [Activity(Label = "BadgeCount", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Main);
            var button = this.FindViewById<Button>(Resource.Id.MyButton);

            button.Click += (sender, args) => ShortcutBadger.SetBadge(this, 0);

            ShortcutBadger.SetBadge(this, 10);
        }
    }
}