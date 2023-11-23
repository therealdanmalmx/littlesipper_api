namespace littlesipper_api.Models
{
    [Flags]
    public enum Amenities
    {
        None = 0,
        Changeroom = 1,
        Toys = 2,
        Books = 4,
        Playground = 8,
        Garden = 16

    }
}