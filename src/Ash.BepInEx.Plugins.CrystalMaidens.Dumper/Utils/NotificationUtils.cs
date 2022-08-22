using System;
using UnityEngine;
using VandalFramework;

namespace Ash.BepInEx.Plugins.CrystalMaidens.Dumper.Utils
{
	internal static class NotificationUtils
	{
		public static void EnableNotifications<T>() where T : IEvent
		=> ((IEventHandler<T>)GameObject.FindObjectOfType<NotificationsPanel>()).Subscribe();

		public static void DisableNotifications<T>() where T : IEvent
			=> ((IEventHandler<T>)GameObject.FindObjectOfType<NotificationsPanel>()).Unsubscribe();
	}

	public class NotificationChangeScope<T> : IDisposable where T : IEvent
	{
		private readonly bool enable;

		private bool disposedValue;

		public NotificationChangeScope(bool enable)
		{
			this.enable = enable;

			Enable(enable);
		}

		private static void Enable(bool enable)
		{
			if (enable)
			{
				NotificationUtils.EnableNotifications<T>();
			}
			else
			{
				NotificationUtils.DisableNotifications<T>();
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					Enable(!enable);
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}
	}
}
