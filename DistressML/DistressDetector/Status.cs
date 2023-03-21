namespace DistressDetector
{
    public class Status
    {
        public struct FR
        {
            //    public int Active; // This is used to check whether a FR has entered a disaster site(1), has been removed(2), or is yet to enter the field(0).
            //    public int ID; // A unique six digit ID to identify a FR.
            public char Gender; // A FR's Gender - either 'M' or 'F'
            public int Age; // Age of FR
            public int BloodOxy; // Blood Oxygen levels
            public int HeartRate; // Heartrate
            public int SysBP; // Systolic Blood Pressure
            public int DiaBP; // Diastolic Blood Pressure
            public int RespRate; // Respiratory rate per minute
            public double TempF; // Temperature in Degrees Fahrenheit

            //private int[] Distress;

            public FR(char Gender, int Age, int BloodOxy, int HeartRate, int SysBP, int DiaBP,
                int RespRate, double TempF, int[] Distress)
            {
                //    this.Active = Active;
                //    this.ID = ID;
                this.Gender = Gender;
                this.Age = Age;
                this.BloodOxy = BloodOxy;
                this.HeartRate = HeartRate;
                this.SysBP = SysBP;
                this.DiaBP = DiaBP;
                this.RespRate = RespRate;
                this.TempF = TempF;
                //this.Distress = new[] { 0, 0, 0, 0, 0 }; // A set of 5 distress values -
                                                         // if all 5 are 1, then send out the distress alert,
                                                         // but if a 0 appears, reset the array back to 0.
            }
        }

        public static bool DistressStatus(FR fr)
        {

            DistressDetect.ModelInput sampleData = new DistressDetect.ModelInput()
            {
                Gender = Char.ToString(fr.Gender),
                Age = fr.Age,
                BloodOxy = fr.BloodOxy,
                HeartRate = fr.HeartRate,
                Systolic_Blood_Pressure = fr.SysBP,
                Diastolic_Blood_Pressure = fr.DiaBP,
                Respiratory_Rate = fr.RespRate,
                Temperature = (float)fr.TempF,
            };
            //Load model and predict output
            bool result = DistressDetect.Predict(sampleData).Distress;
            return result;
        }

        static void Main() { }
    }
}