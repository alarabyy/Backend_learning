using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Rooms
    {
        [Key]
        public int Roomid { get; set; }
        public int Roomnumber { get; set; }
        public string Roomname { get; set; }
        public string Roomdescription { get; set; }
        public string Roomtype { get; set; }

        public ICollection<Client> clients { get; set; }

    }
}
