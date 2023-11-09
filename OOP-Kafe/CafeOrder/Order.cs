using OOP_Kafe.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Kafe.CafeOrder
{
    public class Order
    {
        public OrderItem[] Items { get; }
        public readonly Customer Owner;

        public Order(Customer owner, params OrderItem[] items)
        {
            Owner = owner;
            Items = items;
        }

        //total price
        public decimal TotalPrice => Items.Sum(x => x.Price);

        //total time
        public TimeSpan TotalTime => TimeSpan.FromSeconds(Items.Sum(x => x.PrepTime.TotalSeconds));


    }
}
