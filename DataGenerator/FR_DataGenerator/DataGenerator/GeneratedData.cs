using MonitoringSuiteLibrary.Models;

namespace DataGenerator
{
    public class GeneratedData
    {
        /// <summary>
        /// Check the distress status of a First Responder object using it's age, gender, and vitals data.
        /// </summary>
        /// <param name="f">The first responder for whom we're generating vitals data.</param>
        public Vitals Data(FirstResponder f)
        {
            var r = new Random();
            Vitals v = (Vitals)f.Vitals;
            /// <summary>Get the active status of the first responder to check if they are to be reset to ideal vitals</summary>
            if (!f.Active)
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
                /// <summary>7/100 chance to hit distress state.</summary>
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
                        v.BloodOxy = r.Next(99, 101);
                    }
                    else
                    {
                        v.BloodOxy += r.Next(-1, 2);
                    }

                    v.HeartRate += r.Next(-2, 4);
                    v.SysBP += r.Next(-2, 5);
                    v.DiaBP += r.Next(-1, 3);

                    v.TempF += r.Next(-10, 100) / 100;
                    v.TempF = (float)Math.Round(v.TempF, 2);

                }
            }
            return v;
        } 

    }
}
