using MobileVitalsMonitoringTool.Contracts.Services;
using MonitoringSuiteLibrary.Models;
using System;

namespace DataGenerator
{
    /// <summary>
    /// A  class to generate vitals data to simulate sensors inputting real first responder vitals.
    /// </summary>
    public class GeneratedData : IVitalsData
    {

        private Vitals v = new Vitals()
        {
            BloodOxy = 100,
            HeartRate = 75,
            SysBP = 100,
            DiaBP = 70,
            RespRate = 22,
            TempF = (float)98.6
        };

        /// <summary>
        /// Updates the vitals data of a first responder.
        /// </summary>
        /// <returns>The updated vitals data of the first responder.</returns>
        public Vitals GetVitals()
        {
            var r = new Random();
            Vitals temp = v;


            // 7/100 chance to hit distress state.
            // If we do hit the distress chance, 
            // then we give a greater window for the randomly generated values to 
            // increment/decriment the vitals data elements.
            if (r.Next(0, 100) >= 93)
            {
                temp.BloodOxy += r.Next(-6, -2);
                temp.HeartRate += r.Next(20, 35);
                temp.SysBP += r.Next(20, 35);
                temp.DiaBP += r.Next(10, 20);
                temp.RespRate -= r.Next(4, 10);
                temp.TempF += r.Next(5, 25) / 10;
            }
            else
            {
                // The check below is to make sure we don't go above 100%
                if (temp.BloodOxy == 100)
                {
                    // Blood Oxygen either remains at 100 or goes to 99
                    temp.BloodOxy = r.Next(99, 101);
                }
                else
                {
                    // Blood Oxygen is changed by either -1, 0, or 1 point.
                    temp.BloodOxy += r.Next(-1, 2);
                }

                // Heartrate is increased/decreased by a value between -2 and 4
                temp.HeartRate += r.Next(-2, 5);

                // Systolic Blood Pressure is increased/decreased by a value between -2 and 5
                temp.SysBP += r.Next(-2, 6);

                // Diastolic Blood Pressure is increased/decreased by a value between -1 and 2
                temp.DiaBP += r.Next(-1, 4);

                // Temperature is increased/decreased by a value between -0.1 and 1 degree fahrenheit
                temp.TempF += r.Next(-10, 100) / 100;
                temp.TempF = (float)Math.Round(temp.TempF, 2);

            }

            v = temp;
            return v;
        }
    }
}
