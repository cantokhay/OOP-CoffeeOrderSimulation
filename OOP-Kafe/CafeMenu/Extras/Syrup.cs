
namespace OOP_Kafe.CafeMenu.Extras
{
    internal struct Syrup :IExtra
    {
        public decimal Price => 5.5m;
        public TimeSpan PreparationTime => TimeSpan.FromSeconds(15);
    }
}
