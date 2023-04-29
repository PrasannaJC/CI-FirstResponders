using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Xamarin.Forms;
using MobileVitalsMonitoringTool.Services;

namespace MobileVitalsMonitoringTool.Droid
{
	/// <summary>
	/// A class for the Android specific background service to get location.
	/// </summary>
	[Service]
	public class AndroidLocationService : Service
	{
		CancellationTokenSource _cts;
		public const int SERVICE_RUNNING_NOTIFICATION_ID = 10001;

		/// <summary>
		/// Bind remote call.
		/// </summary>
		/// <param name="intent">An operation to be performed</param>
		/// <returns>null</returns>
		public override IBinder OnBind(Intent intent)
		{
			return null;
		}

		/// <summary>
		/// Starts the background service
		/// </summary>
		/// <param name="intent">An operation to be performed</param>
		/// <param name="flags">Values returned by the StartCommandFlags</param>
		/// <param name="startId">An integer id</param>
		/// <returns><see cref="StartCommandResult"/></returns>
		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			_cts = new CancellationTokenSource();

			Notification notification = new NotificationHelper().GetServiceStartedNotification();
			StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notification);

			Task.Run(() => {
				try
				{
					var locShared = new GetLocationVitalsService();
					locShared.Run(_cts.Token).Wait();
				}
				catch (Android.OS.OperationCanceledException)
				{
				}
				finally
				{
					if (_cts.IsCancellationRequested)
					{
						var message = new StopServiceMessage();
						Device.BeginInvokeOnMainThread(
							() => MessagingCenter.Send(message, "ServiceStopped")
						);
					}
				}
			}, _cts.Token);

			return StartCommandResult.Sticky;
		}

		/// <summary>
		/// Destroys the Android background service.
		/// </summary>
		public override void OnDestroy()
		{
			if (_cts != null)
			{
				_cts.Token.ThrowIfCancellationRequested();
				_cts.Cancel();
			}
			base.OnDestroy();
		}
	}
}

