using System;
using System.Collections.Generic;
using System.Text;
using static MonitoringSuiteLibrary.Distress;
using MonitoringSuiteLibrary.Models;

namespace MonitoringSuiteLibrary.MachineLearning
{
    /// <summary>
    /// A class to check the distress status of first responders.
    /// </summary>
    public class CheckDistress
    {
        /// <summary>
        /// Check the distress status of a First Responder object using it's age, gender, and vitals data.
        /// </summary>
        /// <param name="age">The first responders age id.</param>
        /// <param name="sex">The first responders gender.</param>
        /// <param name="v">The first responders Vitals data.</param>
        /// <returns>Returns a boolean representing the distress status of a first responder.</returns>
        public static bool GetDistressStatus(int age, char sex, Vitals v)
        {

            // The ModelInput object is made using the age, the sex, and the vitals data of the first responder.
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

            // The ModelInput object is then used to predict the distress probability of a first responder.
            ModelOutput status = Distress.Predict(FR);
            float chance = status.Probability;
            bool distress = false;

            // Using the previously obtained probability of being in distress,
            // we determine whether to return True or False.
            // If above or equal to 50%, then yes, the person is in distress (True).
            // If below 50%, then no, the person is not in distress (False).
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
