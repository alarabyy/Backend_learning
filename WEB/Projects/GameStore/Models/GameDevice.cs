using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;

        public int DeviceId { get; set; }
        public Device Device { get; set; } = null!;
    }

 
}