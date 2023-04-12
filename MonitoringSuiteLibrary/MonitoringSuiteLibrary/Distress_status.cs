using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSuiteLibrary
{
    public class Distress_status
    {
        /*
        public void Main()
        {
            
            DistressDetect.ModelInput sampleData = new DistressDetect.ModelInput()
            {
                Gender = "M",
                Age = 39,
                BloodOxy = 100,
                HeartRate = 75,
                Systolic_Blood_Pressure = 100,
                Diastolic_Blood_Pressure = 70,
                Respiratory_Rate = 18,
                Temperature = (float)98.6,
            };
            
            float result = DistressDetect.Predict(sampleData).Probability;

            if (result > 0.5)
            {
                Console.WriteLine(true);
                //return true;
            }
            else
            {
                Console.WriteLine(false);
                //return false;
            }
        }
        */
        public static bool getStatus(DistressDetect.ModelInput sampleData)
        {
            /*
            DistressDetect.ModelInput sampleData = new DistressDetect.ModelInput()
            {
                Gender = "M",
                Age = 39,
                BloodOxy = 100,
                HeartRate = 75,
                Systolic_Blood_Pressure = 100,
                Diastolic_Blood_Pressure = 70,
                Respiratory_Rate = 18,
                Temperature = (float)98.6,
            };
            */
            float result = DistressDetect.Predict(sampleData).Probability;

            if (result > 0.5)
            {
                Console.WriteLine(true);
                return true;
            }
            else
            {
                Console.WriteLine(false);
                return false;
            }
        }

        static void Main()
        {

        }
    }
}
