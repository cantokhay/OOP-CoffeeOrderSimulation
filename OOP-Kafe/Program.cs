using OOP_Kafe;
using OOP_Kafe.CafeMenu;
using OOP_Kafe.CafeMenu.Extras;
using OOP_Kafe.CafeOrder;
using OOP_Kafe.Enums;
using OOP_Kafe.People;

// Initialization
List<Worker> workers = new()
{new Worker("Ahmet"),
new Worker("Mehmet"),
new Worker("Ayşe"),
new Worker("Fatma"),
new Worker("Ali")
};

Cafe cafe = new Cafe(workers,
new MenuItem("Kahve", 45, TimeSpan.FromSeconds(75)),
new MenuItem("Çay", 23, TimeSpan.FromSeconds(90)),
new MenuItem("Su", 21, TimeSpan.FromSeconds(10)),
new MenuItem("Türk Kahvesi", 40, TimeSpan.FromSeconds(10)),
new MenuItem("Mocha", 66, TimeSpan.FromSeconds(10))
);

// Musteri Gelir
var c1 = new Customer("CanTokhay");
Console.WriteLine($"{c1.Name} İsimli Müşteri Gelir...");

// Sıraya Girer
Console.WriteLine($"{c1.Name} İsimli Müşteri Sıraya Girecek...");
cafe.GetInLine(c1);
Console.WriteLine($"{c1.Name} İsimli Müşteri Şu Anda Sırada...");

// Ürün seçer
//Özelliklerini belirtir
Console.WriteLine($"{c1.Name} İsimli Müşteri Siparişini Hazırlıyor...");
var OrderItem = new OrderItem[]
{
    new OrderItem(cafe.Menu["Kahve"],CoffeSize.Medium, new Milk(), new Syrup()),
    new OrderItem(cafe.Menu["Çay"],CoffeSize.Medium),
    new OrderItem(cafe.Menu["Su"],CoffeSize.Small),
    new OrderItem(cafe.Menu["Türk Kahvesi"],CoffeSize.Large),
    new OrderItem(cafe.Menu["Mocha"],CoffeSize.Medium, new Syrup())
};
Console.WriteLine($"{c1.Name} İsimli Müşteri Siparişini detaylandırdı.");

// Sırasını kontrol eder, bekler
while (!cafe.IsNext(c1)) //sıradaki kişi ben değilsem
{
    Console.WriteLine($"{c1.Name} İsimli Müşteri Sırasının Gelmesini Bekliyor");
    await Task.Delay(2000);
}
Console.WriteLine($"{c1.Name} İsimli Müşterinin Sırası Geldi");

// Kasa sipariş alıyor mu
while(!cafe.CanRegisterTakeOrder())
{
    Console.WriteLine($"{c1.Name} İsimli Müşteri Kasanın Sipariş Almasını Bekliyor");
    await Task.Delay(2000);
}
Console.WriteLine("Kasa Sipariş Alıyor");

// sipariş verir
Console.WriteLine($"{c1.Name} İsimli Müşteri Kasaya Siparişini Veriyor");
var receipt = await cafe.RegisterTakeOrder(c1, OrderItem);

// ürünün hazırlanmasını bekler
while(!cafe.IsOrderPrepared(receipt))
{
    Console.WriteLine($"{c1.Name} İsimli Müşteri Siparişinin Hazırlanmasını Bekliyor");
    await Task.Delay(30000);
}
Console.WriteLine($"{c1.Name} İsimli Müşterinin Siparişi Hazır");
// ürünü alır
Order preparedOrder = cafe.ServeOrder(receipt);
Console.WriteLine($"{c1.Name} İsimli Müşteri Siparişini Aldı");

//Kafeden ayrılır
Console.WriteLine($"{c1.Name} İsimli Müşteri Cafeden Ayrılıyor..");

