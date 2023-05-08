using MobileVitalsMonitoringTool.Contracts.Services;
using MonitoringSuiteLibrary.Models;
using System;

namespace MobileVitalsMonitoringTool.Services
{
    /// <summary>
    /// A class to generate vitals data to simulate sensors inputting real first responder vitals.
    /// </summary>
    public class GeneratedData : IVitalsData
    {

        private Vitals v = new Vitals()
        {
            BloodOxy = 100,
            HeartRate = 85,
            SysBP = 100,
            DiaBP = 68,
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

            /// <summary>
            /// This section is for when we hit the 6/100 chance that a first responder's vitals spike to distress levels instead of gradually changing.
            /// </summary>
            // 6/100 chance to hit distress state.
            // If we do hit the distress chance, 
            // then we give a greater window for the randomly generated values to 
            // increment/decriment the vitals data elements.
            if (r.Next(0, 100) >= 94)
            {

                switch (temp.BloodOxy)
                {
                    case (92):
                        temp.BloodOxy += 0;
                        break;
                    case (93):
                        temp.BloodOxy += r.Next(-1, 0);
                        break;
                    case (94):
                        temp.BloodOxy += r.Next(-2, 0);
                        break;
                    case (95):
                        temp.BloodOxy += r.Next(-3, 0);
                        break;
                    case (96):
                        temp.BloodOxy += r.Next(-4, 0);
                        break;
                    case (97):
                        temp.BloodOxy += r.Next(-5, 0);
                        break;
                    default:
                        temp.BloodOxy += r.Next(-6, 0);
                        break;
                }


                if (temp.HeartRate < 75) { temp.HeartRate += r.Next(50, 65); }
                else if (temp.HeartRate > 75 && temp.HeartRate <= 180) { temp.HeartRate += r.Next(20, 35); }
                else if (temp.HeartRate > 180 && temp.HeartRate <= 185) { temp.HeartRate += r.Next(15, 21); }
                else if (temp.HeartRate > 185 && temp.HeartRate <= 190) { temp.HeartRate += r.Next(10, 16); }
                else if (temp.HeartRate > 190 && temp.HeartRate <= 203) { temp.HeartRate += r.Next(5, 10); }
                else { temp.HeartRate += 0; }


                if (temp.SysBP < 145) { temp.SysBP += r.Next(15, 25); }
                else if (temp.SysBP <= 155) { temp.SysBP += r.Next(10, 16); }
                else if (temp.SysBP > 155 && temp.SysBP < 167) { temp.SysBP += 3; }
                else { temp.SysBP += 0; }


                if (temp.DiaBP <= 87) { temp.DiaBP += r.Next(1, 5); }
                else if (temp.DiaBP > 87 && temp.DiaBP <= 92) { temp.DiaBP += r.Next(1, 3); }
                else if (temp.DiaBP > 92) { temp.DiaBP += 0; }


                if (temp.BloodOxy > 98) { temp.RespRate = r.Next(20, 25); }
                else if (temp.BloodOxy > 95 && temp.BloodOxy <= 98) { temp.RespRate = r.Next(14, 20); }
                else if (temp.BloodOxy > 93 && temp.BloodOxy <= 95) { temp.RespRate = r.Next(8, 14); }
                else if (temp.BloodOxy >= 92 && temp.BloodOxy <= 93) { temp.RespRate = r.Next(5, 8); }


                if (temp.TempF < 102.4) { temp.TempF += r.Next(50, 110) / 100; }
                else if (temp.TempF < 103.25) { temp.TempF += r.Next(20, 40) / 100; }
                else { temp.TempF += 0; }
                temp.TempF = (float)Math.Round(temp.TempF, 2);

            }
            else
            {
                /// <summary>
                /// This section is for the general case of generating vitals data i.e. a first responder's vitals change as they would under normal circumstances in a disaster zone.
                /// </summary>
                // The check below is to make sure we don't go above 100%
                if (temp.BloodOxy == 100)
                {
                    // Blood Oxygen either remains at 100 or goes to 99.
                    temp.BloodOxy = r.Next(99, 101);
                }
                else if (temp.BloodOxy > 92)
                {
                    // Blood Oxygen is changed by either -1, 0, or 1 point if it's between 93 and 98 inclusive.
                    temp.BloodOxy += r.Next(-1, 2);
                }
                // If we otherwise have a BloodOxy of 92, we either leave it be or increment it by 1.
                else { temp.BloodOxy += r.Next(0, 2); }

                // RespRate is tied to BloodOxy, and thue the latter's values determine what RespRate will be.
                if (temp.BloodOxy > 98) { temp.RespRate = r.Next(22, 27); }
                else if (temp.BloodOxy > 95 && temp.BloodOxy <= 98) { temp.RespRate = r.Next(15, 22); }
                else if (temp.BloodOxy > 93 && temp.BloodOxy <= 95) { temp.RespRate = r.Next(10, 16); }
                else if (temp.BloodOxy >= 92 && temp.BloodOxy <= 93) { temp.RespRate = r.Next(5, 10); }


                // Heartrate is increased/decreased by different ranges depending on how high or low it is.
                if (temp.HeartRate < 75) { temp.HeartRate += r.Next(10, 18); }
                else if (temp.HeartRate >= 75 && temp.HeartRate <= 180) { temp.HeartRate += r.Next(-3, 7); }
                else if (temp.HeartRate > 180 && temp.HeartRate <= 210) { temp.HeartRate += r.Next(-2, 5); }
                else if (temp.HeartRate > 210) { temp.HeartRate += r.Next(-1, 0); }


                // Systolic Blood Pressure is increased/decreased by different ranges depending on how high or low it is.
                if (temp.SysBP < 160) { temp.SysBP += r.Next(-2, 4); }
                else if (temp.SysBP >= 160 && temp.SysBP < 166){ temp.SysBP += r.Next(-1, 2); }
                else { temp.SysBP += 0; }


                // Diastolic Blood Pressure is increased/decreased by different ranges depending on how high or low it is.

                if (temp.DiaBP <= 56) { temp.DiaBP += r.Next(2, 5); }
                else if (temp.DiaBP > 56 && temp.DiaBP <= 81) { temp.DiaBP += r.Next(-2, 3); }
                else if (temp.DiaBP > 81 && temp.DiaBP <= 92) { temp.DiaBP += r.Next(-2, 2); }
                else if (temp.DiaBP > 92 && temp.DiaBP <= 100) { temp.DiaBP += r.Next(-1, 2); }
                else { temp.DiaBP += 0; }


                // Temperature is increased/decreased by different ranges depending on how high or low it is.
                // If we go too low, we only increment.
                if (temp.TempF < 96.99)
                {
                    temp.TempF += r.Next(25, 50) / 100;
                }
                else if (temp.TempF > 96.99 && temp.TempF < 103.15)
                {
                    temp.TempF += r.Next(-20, 51) / 100;
                }
                else if (temp.TempF >= 103.15 && temp.TempF < 103.4)
                {
                    temp.TempF += r.Next(-30, 30) / 100;
                }
                else
                {
                    temp.TempF += 0;
                } 
                temp.TempF = (float)Math.Round(temp.TempF, 2);
            }

            v = temp;
            return v;
        }
    }
}
