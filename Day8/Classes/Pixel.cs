namespace Day8.Classes
{
    public class Pixel
    {
        public bool IsActive { get; set; }      // current

        public Pixel(bool isActive)
        {
            this.IsActive = isActive;
        }
    }
}
