using OOP_Kafe.CafeMenu;
using OOP_Kafe.CafeMenu.Extras;
using OOP_Kafe.Enums;

namespace OOP_Kafe.CafeOrder
{
    public class OrderItem
    {
        public MenuItem Item { get; }
        public CoffeSize Size { get; }

        public IExtra[] Extras { get; }

        public OrderItem(MenuItem item, CoffeSize size, params IExtra[] extras)
        {
            Item = item;
            Size = size;
            Extras = extras;
            Price = Item.Price + (int)Size + Extras.Sum(x => x.Price);
            PrepTime = TimeSpan.FromSeconds(Item.PreparationTime.TotalSeconds + (int)Size + Extras.Sum(x => x.PreparationTime.TotalSeconds));
        }

        public decimal Price { get; }
        public TimeSpan PrepTime { get; }

    }
}