using static DistressDetector.Status;
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

            Assert.Equal(false, d);
        }

        [Fact]
        public void Test_IN_Distress()
        {

            Status.FR fR = new Status.FR();

            fR.Gender = 'F';
            fR.Age = 64;
            fR.BloodOxy = 92;
            fR.HeartRate = 195;
            fR.SysBP = 179;
            fR.DiaBP = 96;
            fR.RespRate = 5;
            fR.TempF = 103.6;

            bool d = Status.DistressStatus(fR);

            Assert.Equal(true, d);
        }
    }
}
