
namespace MobileAppEFexample
{
    public class Run
    {
        public int RunID { get; set; }
        public float DistanceInKM { get; set; }
        public int TimeInMins { get; set; }
        public int TimeInSeconds { get; set; }
        public string Terrain { get; set; }

        public string Pace { get; set; }
        public int PersonID { get; set; }
        public Person person { get; set; }

        public void setPace()
        {
            int fullSeconds = (TimeInMins * 60) + TimeInSeconds;

            int secondsPerKm = fullSeconds / (int)DistanceInKM;

            double minutesPerKm = secondsPerKm / 60;
            int leftOverSeconds = secondsPerKm % 60;

            Pace = minutesPerKm.ToString() + "'" +leftOverSeconds.ToString() + "\"";
        }
    }
}
