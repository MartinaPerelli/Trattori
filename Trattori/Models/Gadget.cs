namespace Trattori.Models
{
    public class Gadget
    {
        public int Id { get; set; }
        public string? GadgetName { get; set; }
        public Gadget()
        {

        }
        public Gadget(int id, string? gadgetName)
        {
            Id = id;
            GadgetName = gadgetName;
        }
    }
}