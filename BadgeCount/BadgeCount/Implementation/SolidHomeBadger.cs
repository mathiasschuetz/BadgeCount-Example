using System.Collections.Generic;
using Android.Content;
using BadgeCount.BadgeCount.Infrastructure;

namespace BadgeCount.BadgeCount.Implementation
{
    /**
	 * @author MajeurAndroid
	 */

    internal class SolidHomeBadger : BaseShortcutBadger
    {
        private const string IntentUpdateCounter = "com.majeur.launcher.intent.action.UPDATE_BADGE";
        private const string Packagename = "com.majeur.launcher.intent.extra.BADGE_PACKAGE";
        private const string Count = "com.majeur.launcher.intent.extra.BADGE_COUNT";
        private const string Class = "com.majeur.launcher.intent.extra.BADGE_CLASS";

        public SolidHomeBadger(Context context)
            : base(context)
        {
        }

        #region IShortcutBadger implementation

        public override void ExecuteBadge(int badgeCount)
        {
            var intent = new Intent(IntentUpdateCounter);
            intent.PutExtra(Packagename, this.ContextPackageName);
            intent.PutExtra(Count, badgeCount);
            intent.PutExtra(Class, this.EntryActivityName);
            this._context.SendBroadcast(intent);
        }

        public override IEnumerable<string> SupportLaunchers
        {
            get { return new[] {"com.majeur.launcher"}; }
        }

        #endregion
    }
}