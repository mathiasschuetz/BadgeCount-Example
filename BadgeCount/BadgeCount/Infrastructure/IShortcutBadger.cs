using System.Collections.Generic;

namespace BadgeCount.BadgeCount.Infrastructure
{
	public interface IShortcutBadger
	{
		IEnumerable<string> SupportLaunchers { get; }

		void ExecuteBadge(int badgeCount);
	}
}

