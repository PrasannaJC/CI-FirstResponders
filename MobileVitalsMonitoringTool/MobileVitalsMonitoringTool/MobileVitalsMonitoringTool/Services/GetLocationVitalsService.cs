using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using MonitoringSuiteLibrary.Models;
using MobileVitalsMonitoringTool.Contracts.Services;

namespace MobileVitalsMonitoringTool.Services
{
    /// <summary>
    /// A class to get the location and vitals of a first responder.
    /// </summary>
    public class GetLocationVitalsService
	{
		readonly bool stopping = false;
		IVitalsData dataGenerator;

        /// <summary>
        /// Creates a <see cref="GetLocationService"/>.
        /// </summary>
        public GetLocationVitalsService()
		{
			dataGenerator = new GeneratedData();
		}

        /// <summary>
        /// Initiates a loop to get the location and vitals of a first responder
        /// until a cancellation token is received.
        /// </summary>
        /// <param name="token">A cancellation token to stop the loop.</param>
        /// <returns></returns>
        public async Task Run(CancellationToken token)
		{
			await Task.Run(async () => {
				while (!stopping)
				{
					token.ThrowIfCancellationRequested();
					try
					{
						await Task.Delay(2000);

						// get location
						var request = new GeolocationRequest(GeolocationAccuracy.High);
						var location = await Geolocation.GetLocationAsync(request);
						if (location != null)
						{
							var locationMessage = new LocationMessage
							{
								Location = new MonitoringSuiteLibrary.Models.Location((decimal)location.Longitude, (decimal)location.Latitude, (decimal)location.Altitude)
							};

							Device.BeginInvokeOnMainThread(() =>
							{
								MessagingCenter.Send(locationMessage, "Location");
							});
						}

						// get vitals
						var vitalsMessage = new VitalsMessage
						{
							Vitals = dataGenerator.GetVitals()
						};

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            MessagingCenter.Send(vitalsMessage, "Vitals");
                        });

                    }
					catch (Exception ex)
					{
						Device.BeginInvokeOnMainThread(() =>
						{
							var errormessage = new ErrorMessage();
							MessagingCenter.Send(errormessage, "LocationVitalsError");
						});
					}
				}
				return;
			}, token);
		}
	}
}

