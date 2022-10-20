using System.Drawing;

namespace Trattori.Models
{
    public class PostTractorModel
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public MyColor Color { get; set; }

        public List<Gadget> Gadgets { get; set; }
    }
}
