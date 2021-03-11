using System.Collections.Generic;

namespace MobileAppEFexample
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public List<Run> Runs { get; set; } = new List<Run>();
    }
}
