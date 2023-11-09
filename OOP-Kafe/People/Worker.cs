using OOP_Kafe.CafeOrder;
using OOP_Kafe.Enums;

namespace OOP_Kafe.People
{
    public class Worker : Person
    {

        public WorkerStatus Status { get; private set; } = WorkerStatus.Available;
        public Worker(string name) : base(name)
        { 
        }

        public async Task<Order> TakeOrder(Cafe cafe, Customer customer, params OrderItem[] orderItems)
        {
            Status = WorkerStatus.TakingOrder;
            Console.WriteLine($"{Name} İsimli Çalışan {customer.Name} İsimli Müşteriden Sipariş Alıyor");
            var order = new Order(customer, orderItems);
            await Task.Delay(5000);

            //çalışana siparişi gönder
            var preparer = cafe.GetWorker() ?? this;

            preparer.PrepareOrder(cafe, order); //fire and forget 

            Status = WorkerStatus.Available;
            return order;
        }

        private async Task PrepareOrder(Cafe cafe, Order order)
        {
            Status = WorkerStatus.PreparingOrder;
            Console.WriteLine($"{Name} İsimli Çalışan {order.Owner.Name} İsimli Müşterinin Siparişini Hazırlıyor");
            await Task.Delay(order.TotalTime);
            cafe.PreparedOrders.Add(order);
            Status = WorkerStatus.Available;
        }
    }
}