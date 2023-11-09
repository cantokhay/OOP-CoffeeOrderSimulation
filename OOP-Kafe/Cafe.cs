
using OOP_Kafe.CafeMenu;
using OOP_Kafe.CafeOrder;
using OOP_Kafe.Enums;
using OOP_Kafe.People;

namespace OOP_Kafe
{
    public class Cafe
    {
        public Cafe(List<Worker> workers, params MenuItem[] menuitems)
        {
            Workers = workers;
            Menu = new Menu(menuitems);
        }

        //menu
        public Menu Menu { get; }

        //sıra
        public Queue<Customer> CustomerLine { get; private set; } = new Queue<Customer>();
        public void GetInLine(Customer customer)
        {
            CustomerLine.Enqueue(customer);
        }

        //calısan
        private List<Worker> Workers { get; }


        //kasa
        public readonly int CashDesk = 3;

        public Order ServeOrder(Order receipt)
        {
            var order = PreparedOrders.FirstOrDefault(Order => Order == receipt);
            if (order != null) 
            {
                PreparedOrders.Remove(order);
                return order;
            }
            throw new Exception("Order not ready!");
        }

        public bool IsOrderPrepared(Order order)
        {
            return PreparedOrders.Contains(order);
        }   

        public List<Order> PreparedOrders { get; } = new();

        public Worker? GetWorker()
        {
            return Workers.FirstOrDefault(Workers => Workers.Status == WorkerStatus.Available);
        }

        public async Task<Order> RegisterTakeOrder(Customer customer, params OrderItem[] orderItems)
        {
            var registerer = Workers.First(Workers => Workers.Status == WorkerStatus.Available);

            CustomerLine.Dequeue();

            return await registerer.TakeOrder(this, customer, orderItems);
        }

        public bool CanRegisterTakeOrder()
        {
            return Workers.Any(Workers => Workers.Status == WorkerStatus.Available) && Workers.Count(Workers => Workers.Status == WorkerStatus.TakingOrder) < CashDesk;
        }

        public bool IsNext(Customer customer)
        {
            if (CustomerLine.TryPeek(out var nextCustomer))
            {
                return (nextCustomer == customer);
            }
            return false;
        }
    }
}
