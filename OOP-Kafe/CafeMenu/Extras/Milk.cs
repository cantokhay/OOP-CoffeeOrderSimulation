namespace OOP_Kafe.CafeMenu.Extras
{
    internal struct Milk : IExtra
    {
        public decimal Price => 2.0m;
        public TimeSpan PreparationTime => TimeSpan.FromSeconds(25);
    }
}
