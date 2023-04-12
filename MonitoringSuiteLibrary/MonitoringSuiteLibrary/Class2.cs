using Xunit;

namespace MonitoringSuiteLibrary
{
    public class Class2
    {

        [Fact]
        public void Test_NOT_Distress()
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

            bool d = Class1.status(sampleData);

            Assert.False(d);
        }
        /*
        [Fact]
        public void Test_IN_Distress()
        {

            Status.FR fR = new Status.FR();

            fR.Gender = 'M';
            fR.Age = 61;
            fR.BloodOxy = 93;
            fR.HeartRate = 204;
            fR.SysBP = 177;
            fR.DiaBP = 91;
            fR.RespRate = 5;
            fR.TempF = 103.91;

            bool d = Status.DistressStatus(fR);

            Assert.True(d);
        }*/
    }
}
