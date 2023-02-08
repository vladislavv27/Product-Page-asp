using Microsoft.AspNetCore.Identity;

namespace webProgram3.Models
{
    public class Adress
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string city { get; set; }

        public string streetname { get; set; }
        public int postcode { get; set; }


    }
}
