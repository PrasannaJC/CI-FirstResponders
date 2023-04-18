using Xunit;
using static MonitoringSuiteLibrary.Distress;
using static MonitoringSuiteLibrary.Machine_Learning.checkDistress;

namespace MonitoringSuiteLibrary.Machine_Learning
{
    public class Test
    {
        [Fact]
        public void Test_NOT_Distress()
        {
            ModelInput a = new ModelInput()
            {
                Gender = "M",
                Age = 39,
                BloodOxy = 94,
                HeartRate = 155,
                Systolic_Blood_Pressure = 139,
                Diastolic_Blood_Pressure = 82,
                Respiratory_Rate = 11,
                Temperature = (float)99.95,

            };

            bool k = getDistressStatus(a);

            // Debug.WriteLine("This is the probability " + k);

            Assert.False(k);
        }

        [Fact]
        public void Test_IN_Distress()
        {
            ModelInput a = new ModelInput()
            {
                Gender = "F",
                Age = 59,
                BloodOxy = 93,
                HeartRate = 204,
                Systolic_Blood_Pressure = 177,
                Diastolic_Blood_Pressure = 91,
                Respiratory_Rate = 5,
                Temperature = (float)103.91
            };

            bool k = getDistressStatus(a);

            Assert.True(k);

        }
    }
}
