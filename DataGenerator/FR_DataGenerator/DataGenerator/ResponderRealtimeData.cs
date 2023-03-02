namespace DataGenerator;
using System;

public class ResponderRealtimeData
{
    // Throughout this project, First Responders will be refer to as FR. 
    public struct FR
    {
        public int ID; // A unique six digit ID to identify a FR.
        public char Gender; // A FR's Gender - either 'M' or 'F'
        public int Age; // Age of FR
        public int BloodOxy; // Blood Oxygen levels
        public int HeartRate; // Heartrate
        public int SysBP; // Systolic Blood Pressure
        public int DiaBP; // Diastolic Blood Pressure
        public int RespRate; // Respiratory rate per minute
        public int TempF; // Temperature in Degrees Fahrenheit
    }
    public static void main()
    {
        Console.WriteLine("Hello there");
    }

    public static void ResponderInstance(FR fr)
    {
        char[] g = new char[] { 'M', 'F' };
        Random r = new Random();
        int k = r.Next(0, g.Length);
        
        fr.ID = r.Next(100000, 999999);
        fr.Age = r.Next(21, 69);
        fr.Gender = g[k];
        
        
        
    }

    void Data()
    {
        
    }
}