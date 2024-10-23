namespace GameStore.Models
{
    public class GameDevice
    {
        public int Gameid { get; set; }
        public Game game { get; set; }

        public int Deviceid { get; set; }
        public Device device { get; set; }
    }
}
