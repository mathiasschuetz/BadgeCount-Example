using System.Collections.Generic;
using Android.Content;
using BadgeCount.BadgeCount.Infrastructure;

namespace BadgeCount.BadgeCount.Implementation
{
    /**
	 * @author leolin
	 */

    internal class AsusHomeLauncher : BaseShortcutBadger
    {
        private const string IntentAction = "android.intent.action.BADGE_COUNT_UPDATE";
        private const string IntentExtraBadgeCount = "badge_count";
        private const string IntentExtraPackagename = "badge_count_package_name";
        private const string IntentExtraActivityName = "badge_count_class_name";
        private const string IntentExtraBadgeVipCount = "badge_vip_count";

        public AsusHomeLauncher(Context context)
            : base(context)
        {
        }

        #region IShortcutBadger implementation

        public override void ExecuteBadge(int badgeCount)
        {
            var intent = new Intent(IntentAction);
            intent.PutExtra(IntentExtraBadgeCount, badgeCount);
            intent.PutExtra(IntentExtraPackagename, this.ContextPackageName);
            intent.PutExtra(IntentExtraActivityName, this.EntryActivityName);
            intent.PutExtra(IntentExtraBadgeVipCount, 0);
            this._context.SendBroadcast(intent);
        }

        public override IEnumerable<string> SupportLaunchers
        {
            get { return new[] {"com.asus.launcher"}; }
        }

        #endregion
    }
}