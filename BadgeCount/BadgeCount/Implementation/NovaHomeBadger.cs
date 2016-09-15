using System.Collections.Generic;
using Android.Content;
using Android.Net;
using BadgeCount.BadgeCount.Infrastructure;
using Java.Lang;
using Exception = System.Exception;

namespace BadgeCount.BadgeCount.Implementation
{
	/**
	 * Shortcut Badger support for Nova Launcher.
	 * TeslaUnread must be installed.
	 * User: Gernot Pansy
	 * Date: 2014/11/03
	 * Time: 7:15
	 */

	internal class NovaHomeBadger : BaseShortcutBadger
	{
		private const string ContentUri = "content://com.teslacoilsw.notifier/unread_count";
		private const string Count = "count";
		private const string Tag = "tag";
		private const string IntentTagValueFormat = "{0}/{1}";

		public NovaHomeBadger(Context context)
			: base(context)
		{
		}

		#region IShortcutBadger implementation

		public override void ExecuteBadge(int badgeCount)
		{
			try
			{
				var contentValues = new ContentValues();
				contentValues.Put(Tag,
					string.Format(IntentTagValueFormat, this.ContextPackageName, this.EntryActivityName));
				contentValues.Put(Count, badgeCount);
				this._context.ContentResolver.Insert(Uri.Parse(ContentUri), contentValues);
			}
			catch (IllegalArgumentException)
			{
				/* Fine, TeslaUnread is not installed. */
			}
			catch (Exception ex)
			{
				/* Some other error, possibly because the format
				of the ContentValues are incorrect. */

				throw new ShortcutBadgeException(ex.Message);
			}
		}

		public override IEnumerable<string> SupportLaunchers
		{
			get { return new[] {"com.teslacoilsw.launcher"}; }
		}

		#endregion
	}
}