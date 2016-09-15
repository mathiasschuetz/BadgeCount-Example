using System.Collections.Generic;
using Android.Content;
using BadgeCount.BadgeCount.Infrastructure;

namespace BadgeCount.BadgeCount.Implementation
{
    /**
	 * @author Leo Lin
	 */

    internal class NewHtcHomeBadger : BaseShortcutBadger
    {
        private const string IntentUpdateShortcut = "com.htc.launcher.action.UPDATE_SHORTCUT";
        private const string IntentSetNotification = "com.htc.launcher.action.SET_NOTIFICATION";
        private const string Packagename = "packagename";
        private const string Count = "count";
        private const string ExtraComponent = "com.htc.launcher.extra.COMPONENT";
        private const string ExtraCount = "com.htc.launcher.extra.Count";

        public NewHtcHomeBadger(Context context)
            : base(context)
        {
        }

        #region IShortcutBadger implementation

        public override void ExecuteBadge(int badgeCount)
        {
            var intent1 = new Intent(IntentSetNotification);
            var localComponentName = new ComponentName(this.ContextPackageName, this.EntryActivityName);
            intent1.PutExtra(ExtraComponent, localComponentName.FlattenToShortString());
            intent1.PutExtra(ExtraCount, badgeCount);
            this._context.SendBroadcast(intent1);

            var intent = new Intent(IntentUpdateShortcut);
            intent.PutExtra(Packagename, this.ContextPackageName);
            intent.PutExtra(Count, badgeCount);
            this._context.SendBroadcast(intent);
        }

        public override IEnumerable<string> SupportLaunchers
        {
            get { return new[] {"com.htc.launcher"}; }
        }

        #endregion
    }
}