using static DataGenerator.ResponderRealtimeData;

namespace DataGenerator;
/**
 * Author => Prasanna J Chandrasekar
 * Start Date => 02/28/2023
 * Objective:
 *      This is a C# Project meant to provide a simulation of real-time first responder vitals data.
 */
public class ResponderRealtimeData
{

    // Throughout this project, First Responders will be refer to as FR. 
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

        //  private int[] Distress;

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
        //    this.Distress = new []{0,0,0,0,0}; // A set of 5 distress values -
                                                   // if all 5 are 1, then send out the distress alert,
                                                   // but if a 0 appears, reset the array back to 0.
        }
    }
    /*
    private static FR NewResponder()
    {
        FR fr = new FR();
        char[] g = new char[] { 'M', 'F' };
        var r = new Random();
        int k = r.Next(0, g.Length);
        
    //    fr.ID = r.Next(100000, 999999);
    //    fr.Age = r.Next(21, 69);
    //    fr.Gender = g[k];
    //    fr.Active = 0;
        
        fr.BloodOxy = 100;
        fr.HeartRate = 85;
        fr.SysBP = 100;
        fr.DiaBP = 70;
        fr.RespRate = 18;
        fr.TempF = 98.6;
        
        return fr;
    }
    */

    public static FR Generate(FR fr)
    {
        {

            var r = new Random();
            if (fr.Age == 0) // The setup for a first responder with ideal vitals,
                                // like just before they enter a disaster zone.
            {
                char[] g = new char[] { 'M', 'F' };
                int k = r.Next(0, g.Length);

                fr.Age = r.Next(21, 69);
                fr.Gender = g[k];
                fr.BloodOxy = 100;
                fr.HeartRate = 75;
                fr.SysBP = 100;
                fr.DiaBP = 70;
                fr.RespRate = 22;
                fr.TempF = 98.6;

            }
            else
            {
                if (r.Next(0, 100) >= 93) // 7/100 chance to hit distress state.
                {
                    fr.BloodOxy += r.Next(-6, -2);
                    fr.HeartRate += r.Next(20, 35);
                    fr.SysBP += r.Next(20, 35);
                    fr.DiaBP += r.Next(10, 20);
                    fr.RespRate -= r.Next(4, 10);
                    // temp = (double)r.Next(5, 25) / 10;
                    fr.TempF += (double)r.Next(5, 25) / 10;
                }
                else
                {
                    // First, let's handle the blood oxygen levels - the check below is to make sure we don't go above 100%.
                    if (fr.BloodOxy == 100)
                    {
                        fr.BloodOxy = r.Next(99, 101);
                    }
                    else
                    {
                        fr.BloodOxy += r.Next(-1, 2);
                    }

                    // Next, we go to heart rate.
                    fr.HeartRate += r.Next(-2, 4);
                    // Now we're updating blood pressure with a random system for slowly incrementing vitals.
                    fr.SysBP += r.Next(-2, 5);
                    fr.DiaBP += r.Next(-1, 3);
                    // Next is temperature
                    // temp = (double)r.Next(-1000, 1000) / 1000;
                    fr.TempF += (double)r.Next(-10, 100) / 100;
                    fr.TempF = Math.Round(fr.TempF, 2);

                }
            }
            return fr;
        }
    }

    static void Main() 
    {
        FR fR = new FR();

        /*-------------------------- New First Responder ---------------------------------*/

        fR.Gender = 'X';
        fR.Age = 0;
        fR.BloodOxy = 0;
        fR.HeartRate = 0;
        fR.SysBP = 0;
        fR.DiaBP = 0;
        fR.RespRate = 0;
        fR.TempF = 0;

        FR d = Generate(fR);
        //System.Diagnostics.Debug.WriteLine("Hello");
        Console.WriteLine("New First Responder Vitals: \nFR Age => {0}\n" +
                      "FR Gender => {1}\n" + "FR Blood Oxygen => {2}\n" +
                      "FR Heart rate => {3}\nFR Systolic Blood Pressure => {4}\n" +
                      "FR Diastolic Blood Pressure => {5}\nFR Respiratory rate => {6}\n" +
                      "FR Temperature => {7}\n",
                      d.Age, d.Gender, d.BloodOxy, d.HeartRate, d.SysBP, d.DiaBP, d.RespRate, d.TempF);

        /*-------------------------- Existing First Responder ---------------------------------*/

        fR.Gender = 'M';
        fR.Age = 39;
        fR.BloodOxy = 97;
        fR.HeartRate = 105;
        fR.SysBP = 112;
        fR.DiaBP = 75;
        fR.RespRate = 19;
        fR.TempF = 99.12;

        d = Generate(fR);
        Console.WriteLine("New First Responder Vitals: \nFR Age => {0}\n" +
                      "FR Gender => {1}\n" + "FR Blood Oxygen => {2}\n" +
                      "FR Heart rate => {3}\nFR Systolic Blood Pressure => {4}\n" +
                      "FR Diastolic Blood Pressure => {5}\nFR Respiratory rate => {6}\n" +
                      "FR Temperature => {7}\n",
                      d.Age, d.Gender, d.BloodOxy, d.HeartRate, d.SysBP, d.DiaBP, d.RespRate, d.TempF);
    }



}