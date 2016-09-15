using System;

namespace BadgeCount.BadgeCount.Infrastructure
{
	public class ShortcutBadgeException : Exception
	{
		public ShortcutBadgeException(string message)
			: base(message)
		{
		}
	}
}

