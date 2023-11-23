namespace littlesipper_api.Models
{
    public class Amenities
    {
        public bool Changeroom { get; set; } = false;
        public bool Toys { get; set; } = false;
        public bool Books { get; set; } = false;
        public bool Playground { get; set; } = false;
        public bool Garden { get; set; } = false;

        public Amenities(bool changeroom, bool toys, bool books, bool playground, bool garden)
        {
            Changeroom = changeroom;
            Toys = toys;
            Books = books;
            Playground = playground;
            Garden = garden;
        }
    }
}