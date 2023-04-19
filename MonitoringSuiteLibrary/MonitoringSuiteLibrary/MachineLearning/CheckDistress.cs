using System;
using System.Collections.Generic;
using System.Text;
using static MonitoringSuiteLibrary.Distress;
using MonitoringSuiteLibrary.Models;

namespace MonitoringSuiteLibrary.MachineLearning
{
    public class CheckDistress
    {

        /// <summary>
        /// Check the distress status of a First Responder object using it's age, gender, and vitals data.
        /// </summary>
        /// <param name="age">The first responders age id.</param>
        /// <param name="sex">The first responders gender.</param>
        /// <param name="v">The first responders Vitals data.</param>
        /// <returns>Returns a boolean representing the distress status of a first responder.</returns>


        public static bool GetDistressStatus(int age, 
            char sex,
            Vitals v
            )
        {
            ModelInput FR = new ModelInput()
            {
                Age = age,
                Gender = sex.ToString(),
                HeartRate = v.HeartRate,
                BloodOxy = v.BloodOxy,
                Systolic_Blood_Pressure = v.SysBP,
                Diastolic_Blood_Pressure = v.DiaBP,
                Respiratory_Rate = v.RespRate,
                Temperature = v.TempF
            };

            ModelOutput status = Distress.Predict(FR);
            float chance = status.Probability;
            bool distress = false;
            if (chance >= 0.5)
            {
                distress = true;
            }
            else if (chance < 0.5)
            {
                distress = false;
            }

            return distress;
        }
    }


}
