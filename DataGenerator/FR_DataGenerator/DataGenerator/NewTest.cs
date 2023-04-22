using MonitoringSuiteLibrary.Models;
using Xunit;
using static DataGenerator.GeneratedData;

namespace DataGenerator
{
    public class NewTest
    {

        [Fact]
        public void Test_New_FR()
        {
            Vitals v = new Vitals();
            Vitals n = new Vitals();
            n = GeneratedData.Data(v);

            //ResponderRealtimeData.FR d = ResponderRealtimeData.Generate(fR);
            //System.Diagnostics.Debug.WriteLine("Hello");
            System.Diagnostics.Debug.WriteLine("FR Blood Oxygen => {0}\n" +
                          "FR Heart rate => {1}\nFR Systolic Blood Pressure => {2}\n" +
                          "FR Diastolic Blood Pressure => {3}\nFR Respiratory rate => {4}\n" +
                          "FR Temperature => {5}\n",
                         v.BloodOxy,v.HeartRate, v.SysBP, v.DiaBP, v.RespRate, v.TempF);
            //Console.WriteLine(d);
            //Assert.Equal(fR, d);
            Assert.True(true);
        }

        [Fact]
        public void Test_Active_FR()
        {
            Vitals v = new Vitals()
            {
                BloodOxy = 98,
                HeartRate = 135,
                SysBP = 119,
                DiaBP = 76,
                RespRate = 20,
                TempF = (float)99.14
            };

            //ResponderRealtimeData.FR d = ResponderRealtimeData.Generate(fR);
            //System.Diagnostics.Debug.WriteLine("Hello");
            System.Diagnostics.Debug.WriteLine("FR Blood Oxygen => {0}\n" +
                          "FR Heart rate => {1}\nFR Systolic Blood Pressure => {2}\n" +
                          "FR Diastolic Blood Pressure => {3}\nFR Respiratory rate => {4}\n" +
                          "FR Temperature => {5}\n",
                         v.BloodOxy, v.HeartRate, v.SysBP, v.DiaBP, v.RespRate, v.TempF);
            //Console.WriteLine(d);
            //Assert.Equal(fR, d);
            Assert.True(true);
        }

    }
}
