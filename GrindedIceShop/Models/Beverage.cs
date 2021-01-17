namespace GrindedIceShop.Models
{
    public abstract class Beverage
    {
        public int BeverageId { get; set; }
        public int BeverageName { get; set; }
        public abstract decimal Cost { get; set; }
        public string Description { get; set; }

        public abstract void PrepareBererage();
    }
}
