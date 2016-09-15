using System.Collections.Generic;
using Android.Content;
using BadgeCount.BadgeCount.Infrastructure;

namespace BadgeCount.BadgeCount.Implementation
{
	/**
	 * @author Gernot Pansy
	 */

	internal class ApexHomeBadger : BaseShortcutBadger
	{
		private const string IntentUpdateCounter = "com.anddoes.launcher.COUNTER_CHANGED";
		private const string Packagename = "package";
		private const string Count = "count";
		private const string Class = "class";

		public ApexHomeBadger(Context context)
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
			get { return new[] {"com.anddoes.launcher"}; }
		}

		#endregion
	}
}