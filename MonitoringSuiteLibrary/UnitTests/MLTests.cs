using MonitoringSuiteLibrary.Models;
using MonitoringSuiteLibrary.MachineLearning;
using Xunit;

namespace UnitTests
{
    public class MLTests
    {
        [Fact]
        public void TestNotDistress()
        {
            Vitals v = new Vitals()
            {
                BloodOxy = 94,
                HeartRate = 155,
                SysBP = 129,
                DiaBP = 82,
                RespRate = 11,
                TempF = (float)99.95,
            };

            char g = 'M';
            int a = 39;
            string path = "MachineLearning\\DistressONNXModel.onnx";
            
            // string path = "data\\user\\0\\com.frs.mobilevitalsmonitoringtool\\files\\.local\\share\\DistressONNXModel.onnx";
            bool z = CheckDistressONNX.GetDistressStatus(a, g, v, path);

            // bool k = CheckDistress.GetDistressStatus(a, g, v);

            Assert.False(z);
        }

        [Fact]
        public void TestInDistress()
        {

            Vitals v = new Vitals()
            {
                BloodOxy = 93,
                HeartRate = 185,
                SysBP = 157,
                DiaBP = 88,
                RespRate = 6,
                TempF = (float)103.24,
            };

            char g = 'F';
            int a = 59;

            // bool k = CheckDistress.GetDistressStatus(a, g, v);
            string path = "MachineLearning\\DistressONNXModel.onnx";
            bool z = CheckDistressONNX.GetDistressStatus(a, g, v, path);

            Assert.True(z);

        }
    }
}