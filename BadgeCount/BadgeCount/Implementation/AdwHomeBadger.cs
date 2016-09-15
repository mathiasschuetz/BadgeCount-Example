using System.Collections.Generic;
using Android.Content;
using BadgeCount.BadgeCount.Infrastructure;

namespace BadgeCount.BadgeCount.Implementation
{
    /**
	 * @author Gernot Pansy
	 */

    internal class AdwHomeBadger : BaseShortcutBadger
    {
        private const string IntentUpdateCounter = "org.adw.launcher.counter.SEND";
        private const string Packagename = "PNAME";
        private const string Count = "Count";

        public AdwHomeBadger(Context context)
            : base(context)
        {
        }

        #region IShortcutBadger implementation

        public override void ExecuteBadge(int badgeCount)
        {
            var intent = new Intent(IntentUpdateCounter);
            intent.PutExtra(Packagename, this.ContextPackageName);
            intent.PutExtra(Count, badgeCount);
            this._context.SendBroadcast(intent);
        }

        public override IEnumerable<string> SupportLaunchers => new[]
        {
            "org.adw.launcher",
            "org.adwfreak.launcher"
        };

        #endregion
    }
}