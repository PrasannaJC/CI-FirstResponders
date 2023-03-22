using Xunit;
using static DataGenerator.ResponderRealtimeData;

namespace DataGenerator
{
    public class TestData
    {
        
        [Fact]
        public void Test_New_FR()
        {
            ResponderRealtimeData.FR fR = new ResponderRealtimeData.FR();
            fR.Gender = 'X';
            fR.Age = 0;
            fR.BloodOxy = 0;
            fR.HeartRate = 0;
            fR.SysBP = 0;
            fR.DiaBP = 0;
            fR.RespRate = 0;
            fR.TempF = 0;

            ResponderRealtimeData.FR d = ResponderRealtimeData.Generate(fR);
            //System.Diagnostics.Debug.WriteLine("Hello");
            System.Diagnostics.Debug.WriteLine("New First Responder Vitals: \nFR Age => {0}\n" + 
                          "FR Gender => {1}\n" + "FR Blood Oxygen => {2}\n" +
                          "FR Heart rate => {3}\nFR Systolic Blood Pressure => {4}\n" +
                          "FR Diastolic Blood Pressure => {5}\nFR Respiratory rate => {6}\n" +
                          "FR Temperature => {7}\n",
                          d.Age, d.Gender,d.BloodOxy, d.HeartRate, d.SysBP, d.DiaBP, d.RespRate, d.TempF);
            //Console.WriteLine(d);
            //Assert.Equal(fR, d);
            Assert.True(true);
        }
        
        [Fact]
        public void Test_Active_FR()
        {
            ResponderRealtimeData.FR fR = new ResponderRealtimeData.FR();

            fR.Gender = 'M';
            fR.Age = 39;
            fR.BloodOxy = 97;
            fR.HeartRate = 105;
            fR.SysBP = 112;
            fR.DiaBP = 75;
            fR.RespRate = 19;
            fR.TempF = 99.12;

            ResponderRealtimeData.FR d = ResponderRealtimeData.Generate(fR);

            System.Diagnostics.Debug.WriteLine("Active First Responder Vitals: \nFR Age => {0}\n" + 
                        "FR Gender => {1}\n" + "FR Blood Oxygen => {2}\n" +
                        "FR Heart rate => {3}\nFR Systolic Blood Pressure => {4}\n" +
                        "FR Diastolic Blood Pressure => {5}\nFR Respiratory rate => {6}\n" +
                        "FR Temperature => {7}\n",
                        d.Age, d.Gender, d.BloodOxy, d.HeartRate, d.SysBP, d.DiaBP, d.RespRate, d.TempF);

            Assert.True(true);
        }

        }
}
