using System.Drawing;
using System.Net.NetworkInformation;

namespace Trattori.Models
{
    public class Tractor
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public MyColor Color { get; set; }
        public List<Gadget> Gadgets { get; set; }

    }
}
