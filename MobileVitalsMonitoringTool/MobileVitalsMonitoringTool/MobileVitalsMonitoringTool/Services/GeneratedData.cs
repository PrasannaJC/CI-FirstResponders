using MonitoringSuiteLibrary.Models;
using System;

namespace DataGenerator
{
    public class GeneratedData
    {

        /// <summary>
        /// Check the distress status of a First Responder object using it's age, gender, and vitals data.
        /// </summary>
        /// <param name="v">The first responder for whom we're generating vitals data.</param>
        /// <returns>The changed vitals data of the first responder.</returns>
        public Vitals Data(Vitals v)
        {
            var r = new Random();
            /// <summary>Get the active status of the first responder to check if they are to be reset to ideal vitals</summary>
            if (v.Equals(null))
            {
                v.BloodOxy = 100;
                v.HeartRate = 75;
                v.SysBP = 100;
                v.DiaBP = 70;
                v.RespRate = 22;
                v.TempF = (float)98.6;

            }
            else
            {
                /// <summary>
                /// 7/100 chance to hit distress state.
                /// If we do hit the distress chance, then we give a greater window for the randomly generated values to increment/decriment the vitals data elements.
                /// </summary>
                if (r.Next(0, 100) >= 93)
                {
                    v.BloodOxy += r.Next(-6, -2);
                    v.HeartRate += r.Next(20, 35);
                    v.SysBP += r.Next(20, 35);
                    v.DiaBP += r.Next(10, 20);
                    v.RespRate -= r.Next(4, 10);
                    v.TempF += r.Next(5, 25) / 10;
                }
                else
                {
                    /// <summary>The check below is to make sure we don't go above 100%</summary>
                    if (v.BloodOxy == 100)
                    {
                        /// <summary>
                        /// Blood Oxygen either remains at 100 or goes to 99
                        /// </summary>
                        v.BloodOxy = r.Next(99, 101);
                    }
                    else
                    {
                        /// <summary>
                        /// Blood Oxygen is changed by either -1, 0, or 1 point.
                        /// </summary>
                        v.BloodOxy += r.Next(-1, 2);
                    }
                    /// <summary>
                    /// Heartrate is increased/decreased by a value between -2 and 4
                    /// </summary>
                    v.HeartRate += r.Next(-2, 5);
                    /// <summary>
                    /// Systolic Blood Pressure is increased/decreased by a value between -2 and 5
                    /// </summary>
                    v.SysBP += r.Next(-2, 6);
                    /// <summary>
                    /// Diastolic Blood Pressure is increased/decreased by a value between -1 and 2
                    /// </summary>
                    v.DiaBP += r.Next(-1, 4);
                    /// <summary>
                    /// Temperature is increased/decreased by a value between -0.1 and 1 degree fahrenheit
                    /// </summary>
                    v.TempF += r.Next(-10, 100) / 100;
                    v.TempF = (float)Math.Round(v.TempF, 2);

                }
            }
            //f.Vitals = v;
            return v;
        } 

    }
}
