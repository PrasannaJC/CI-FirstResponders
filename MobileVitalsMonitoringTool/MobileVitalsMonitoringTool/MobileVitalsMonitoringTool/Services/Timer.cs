using System;
using System.Threading;
using Xamarin.Forms;

namespace MobileVitalsMonitoringTool.Services
{
	/// <summary>
	/// A class to construct a countdown timer.
	/// </summary>
	public class Timer
	{
		private readonly TimeSpan _timeSpan;
		private readonly Action _callback;
		private static CancellationTokenSource _cancellationTokenSource;

		/// <summary>
		/// Creates a <see cref="Timer"/>
		/// </summary>
		/// <param name="timeSpan">A TimeSpan object to set the timer limit.</param>
		/// <param name="callback">An Action object to stop the timer if needed.</param>
		public Timer(TimeSpan timeSpan, Action callback)
		{
			_timeSpan = timeSpan;
			_callback = callback;
			_cancellationTokenSource = new CancellationTokenSource();
		}

		/// <summary>
		/// Starts the countdown timer.
		/// </summary>
		public void Start()
		{
			CancellationTokenSource cts = _cancellationTokenSource; // safe copy
			Device.StartTimer(_timeSpan, () =>
			{
				if (cts.IsCancellationRequested)
				{
					return false;
				}

				_callback.Invoke();

				return true; // true to continuous, false to single use
			});
		}

		/// <summary>
		/// Stops the countdown timer.
		/// </summary>
		public void Stop()
		{
            Interlocked.Exchange(ref _cancellationTokenSource, new CancellationTokenSource()).Cancel();
        }
	}
}

