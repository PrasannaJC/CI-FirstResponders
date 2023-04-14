using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileVitalsMonitoringTool.Services
{
    /// <summary>
    /// The GetLocationService class is used to get the location of the device running the application.
    /// </summary>
    public class GetLocationService
	{
		readonly bool stopping = false;

        /// <summary>
        /// Creates a <see cref="GetLocationService"/>.
        /// </summary>
        public GetLocationService()
		{
		}

        /// <summary>
        /// Runs in a loop getting the location coordinates of the device until a cancellation
		/// token is received.
        /// </summary>
        public async Task Run(CancellationToken token)
		{
			await Task.Run(async () => {
				while (!stopping)
				{
					token.ThrowIfCancellationRequested();
					try
					{
						await Task.Delay(2000);

						var request = new GeolocationRequest(GeolocationAccuracy.High);
						var location = await Geolocation.GetLocationAsync(request);
						if (location != null)
						{
							var message = new LocationMessage
							{
								Latitude = location.Latitude,
								Longitude = location.Longitude
							};

							Device.BeginInvokeOnMainThread(() =>
							{
								MessagingCenter.Send(message, "Location");
							});
						}
					}
					catch (Exception ex)
					{
						Device.BeginInvokeOnMainThread(() =>
						{
							var errormessage = new LocationErrorMessage();
							MessagingCenter.Send(errormessage, "LocationError");
						});
					}
				}
				return;
			}, token);
		}
	}
}

