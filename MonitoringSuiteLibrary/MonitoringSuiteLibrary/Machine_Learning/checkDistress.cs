using System;
using System.Collections.Generic;
using System.Text;
using static MonitoringSuiteLibrary.Machine_Learning.checkDistress;
using static MonitoringSuiteLibrary.Distress;

namespace MonitoringSuiteLibrary.Machine_Learning
{
    public class checkDistress
    {

        public static bool getDistressStatus(ModelInput FR) 
        {
            ModelOutput status = Distress.Predict(FR);
            float chance = status.Probability;
            bool d = false;
            if (chance >= 0.5)
            {
                d = true;
            }
            else if (chance < 0.5)
            {
                d = false;
            }
            return d;
        }
    }


}
