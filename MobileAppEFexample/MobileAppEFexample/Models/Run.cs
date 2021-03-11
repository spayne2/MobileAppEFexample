
namespace MobileAppEFexample
{
    public class Run
    {
        public int RunID { get; set; }
        public float DistanceInKM { get; set; }
        public int TimeInMins { get; set; }
        public int TimeInSeconds { get; set; }
        public string Terrain { get; set; }

        public int PersonID { get; set; }
        public Person person { get; set; }
    }
}
