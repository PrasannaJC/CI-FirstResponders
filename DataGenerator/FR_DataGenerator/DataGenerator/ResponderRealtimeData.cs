namespace DataGenerator;
using System;

public class ResponderRealtimeData
{
    // Throughout this project, First Responders will be refer to as FR. 
    private struct FR
    {
        public int active; // This is used to check whether a FR has entered a disaster site.
        public int ID; // A unique six digit ID to identify a FR.
        public char Gender; // A FR's Gender - either 'M' or 'F'
        public int Age; // Age of FR
        public int BloodOxy; // Blood Oxygen levels
        public int HeartRate; // Heartrate
        public int SysBP; // Systolic Blood Pressure
        public int DiaBP; // Diastolic Blood Pressure
        public int RespRate; // Respiratory rate per minute
        public double TempF; // Temperature in Degrees Fahrenheit

        private int[] Distress;

        public FR(int active, int ID, char Gender, int Age, int BloodOxy, int HeartRate, int SysBP, int DiaBP, 
            int RespRate, double TempF, int[] Distress)
        {
            this.active = active;
            this.ID = ID;
            this.Gender = Gender;
            this.Age = Age;
            this.BloodOxy = BloodOxy;
            this.HeartRate = HeartRate;
            this.SysBP = SysBP;
            this.DiaBP = DiaBP;
            this.RespRate = RespRate;
            this.TempF = TempF;
            this.Distress = new int[5]{0,0,0,0,0}; // A set of 5 distress values -
                                                   // if all 5 are 1, then send out the distress alert,
                                                   // but if a 0 appears, reset the array back to 0.
        }
    }
    public static void main()
    {
        int teamSize = 10;
        List<FR> team = new List<FR>();

        for (int i=0; i<teamSize; i++)
        {
            team.Add(NewResponderInstance());
            // team[i] = Data(team[i]);
            Printer(team[i]);
        }
        
        
    }
    private static FR NewResponderInstance()
    {
        FR fr = new FR();
        char[] g = new char[] { 'M', 'F' };
        var r = new Random();
        int k = r.Next(0, g.Length);
        
        fr.ID = r.Next(100000, 999999);
        fr.Age = r.Next(21, 69);
        fr.Gender = g[k];
        fr.active = 0;
        
        fr.BloodOxy = 100;
        fr.HeartRate = 85;
        fr.SysBP = 100;
        fr.DiaBP = 70;
        fr.RespRate = 18;
        fr.TempF = 98.6;
        
        return fr;
    }

    static FR Data(FR fr)
    {
        var r = new Random();
        if (fr.active == 0) // The setup for a first responder with ideal vitals,
                            // like just before they enter a disaster zone.
        {
            fr.BloodOxy = 100;
            fr.HeartRate = 85;
            fr.SysBP = 100;
            fr.DiaBP = 70;
            fr.RespRate = 18;
            fr.TempF = 98.6;
            

            fr.active = 1;
        }
        else if (fr.active == 1) // The setup for a first responder now in the field,
                                 // where their vitals will now fluctuate.
        {
            
        }

        return fr;
    }
    static void Printer(FR fr)
    {
        Console.WriteLine("FR ID => {0}\nFR Gender => {1}\nFR Age => {2}\nFR Blood Oxygen => {3}\nFR Heart rate => {4}\n" +
                          "FR Systolic Blood Pressure => {5}\nFR Diastolic Blood Pressure => {6}\n" +
                          "FR Resperatory rate => {7}\nFR Temperature => {8}\n", 
            fr.ID,fr.Gender,fr.Age,fr.BloodOxy,fr.HeartRate,fr.SysBP,fr.DiaBP,fr.RespRate,fr.TempF);
    }
}