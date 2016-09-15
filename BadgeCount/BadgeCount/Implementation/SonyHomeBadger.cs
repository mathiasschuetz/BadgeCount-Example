using System.Collections.Generic;
using Android.Content;
using BadgeCount.BadgeCount.Infrastructure;

namespace BadgeCount.BadgeCount.Implementation
{
    /**
	 * @author Leo Lin
	 */

    internal class SonyHomeBadger : BaseShortcutBadger
    {
        private const string IntentAction = "com.sonyericsson.home.action.UPDATE_BADGE";
        private const string IntentExtraPackageName = "com.sonyericsson.home.intent.extra.badge.PACKAGE_NAME";
        private const string IntentExtraActivityName = "com.sonyericsson.home.intent.extra.badge.ACTIVITY_NAME";
        private const string IntentExtraMessage = "com.sonyericsson.home.intent.extra.badge.MESSAGE";
        private const string IntentExtraShowMessage = "com.sonyericsson.home.intent.extra.badge.SHOW_MESSAGE";

        public SonyHomeBadger(Context context) : base(context)
        {
        }

        #region IShortcutBadger implementation

        public override void ExecuteBadge(int badgeCount)
        {
            var intent = new Intent(IntentAction);
            intent.PutExtra(IntentExtraPackageName, this.ContextPackageName);
            intent.PutExtra(IntentExtraActivityName, this.EntryActivityName);
            intent.PutExtra(IntentExtraMessage, badgeCount.ToString());
            intent.PutExtra(IntentExtraShowMessage, badgeCount > 0);
            this._context.SendBroadcast(intent);
        }

        public override IEnumerable<string> SupportLaunchers
        {
            get { return new[] {"com.sonyericsson.home"}; }
        }

        #endregion
    }
}