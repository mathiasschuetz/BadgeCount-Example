using System.Collections.Generic;
using Android.Content;
using BadgeCount.BadgeCount.Infrastructure;
using Java.Lang;

namespace BadgeCount.BadgeCount.Implementation
{
    /**
	 * @author leolin
	 */

    internal class XiaomiHomeBadger : BaseShortcutBadger
    {
        private const string IntentAction = "android.intent.action.APPLICATION_MESSAGE_UPDATE";
        private const string ExtraUpdateAppComponentName = "android.intent.extra.update_application_component_name";
        private const string ExtraUpdateAppMsgText = "android.intent.extra.update_application_message_text";

        public XiaomiHomeBadger(Context context)
            : base(context)
        {
        }

        #region IShortcutBadger implementation

        public override void ExecuteBadge(int badgeCount)
        {
            try
            {
                var miuiNotificationClass = Class.ForName("android.app.MiuiNotification");
                var miuiNotification = miuiNotificationClass.NewInstance();
                var field = miuiNotificationClass.GetDeclaredField("messageCount");
                field.Accessible = true;
                field.Set(miuiNotification, String.ValueOf(badgeCount == 0 ? "" : badgeCount.ToString()));
            }
            catch (Exception)
            {
                var localIntent = new Intent(IntentAction);
                localIntent.PutExtra(ExtraUpdateAppComponentName, this.ContextPackageName + "/" + this.EntryActivityName);
                localIntent.PutExtra(ExtraUpdateAppMsgText, String.ValueOf(badgeCount == 0 ? "" : badgeCount.ToString()));
                this._context.SendBroadcast(localIntent);
            }
        }

        public override IEnumerable<string> SupportLaunchers
        {
            get
            {
                return new[]
                {
                    "com.miui.miuilite",
                    "com.miui.home",
                    "com.miui.miuihome",
                    "com.miui.miuihome2",
                    "com.miui.mihome",
                    "com.miui.mihome2"
                };
            }
        }

        #endregion
    }
}