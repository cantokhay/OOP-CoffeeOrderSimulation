

namespace OOP_Kafe.CafeMenu
{
    public class MenuItem
    {
        public MenuItem(string name, decimal price, TimeSpan preparationTime)
        {
            Name = name;
            Price = price;
            PreparationTime = preparationTime;
        }
        public string Name { get;  }
        public decimal Price { get;  }
        public TimeSpan PreparationTime { get; }
    }
}
