using Xunit;

namespace DistressDetector
{
    public class TestCases
    {
        [Fact]
        public void Test_NOT_Distress()
        {

            Status.FR fR = new Status.FR();

            fR.Gender = 'M';
            fR.Age = 39;
            fR.BloodOxy = 100;
            fR.HeartRate = 75;
            fR.SysBP = 100;
            fR.DiaBP = 70;
            fR.RespRate = 18;
            fR.TempF = 98.6;

            bool d = Status.DistressStatus(fR);

            Assert.False(d);
        }

        [Fact]
        public void Test_IN_Distress()
        {

            Status.FR fR = new Status.FR();

            fR.Gender = 'M';
            fR.Age = 68;
            fR.BloodOxy = 93;
            fR.HeartRate = 204;
            fR.SysBP = 177;
            fR.DiaBP = 91;
            fR.RespRate = 6;
            fR.TempF = 103.91;

            bool d = Status.DistressStatus(fR);

            Assert.True(d);
        }
    }
}
