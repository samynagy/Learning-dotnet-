using EFApp.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ApplicationDBContext();

            //Console.WriteLine("EF Core Tests");
            //Console.WriteLine("========================");

            //// ======================================================
            //// TEST 1: INSERT CATEGORY
            //// ======================================================

            //var category = new Category
            //{
            //    Name = "Electronics"
            //};

            //context.categories.Add(category);
            //context.SaveChanges();

            //Console.WriteLine($"Category created: {category.Id}");


            //// ======================================================
            //// TEST 2: INSERT PRODUCTS
            //// ======================================================

            //var laptop = new Product
            //{
            //    Name = "Laptop",
            //    Price = 1200,
            //    CategoryId = category.Id
            //};
            //context.products.Add(laptop);

            //var mouse = new Product
            //{
            //    Name = "Mouse",
            //    Price = 25,
            //    CategoryId = category.Id
            //};

            //context.products.Add(mouse);
            //context.SaveChanges();

            //Console.WriteLine($"Products created: {laptop.Id}, {mouse.Id}");


            //// ======================================================
            //// TEST 3: INSERT CUSTOMER
            //// ======================================================

            //var customer = new Customer
            //{
            //    Name = "Samy",
            //    Email = "samy@example.com"
            //};

            //context.customers.Add(customer);
            //context.SaveChanges();

            //Console.WriteLine($"Customer created: {customer.Id}");


            //// ======================================================
            //// TEST 4: INSERT CUSTOMER PROFILE
            //// One-to-One
            //// ======================================================

            //var profile = new CustomerProfile
            //{
            //    CustomerID = customer.Id,
            //    Birthdate = new DateTime(2003, 7, 28),
            //    Phone = "01000000000"
            //};

            //context.customerProfiles.Add(profile);
            //context.SaveChanges();

            //Console.WriteLine("Customer profile created.");


            //// ======================================================
            //// TEST 5: INSERT ORDER
            //// Customer 1 : Many Orders
            //// ======================================================

            //var order = new Order
            //{
            //    CustomerId = customer.Id
            //};

            //context.orders.Add(order);
            //context.SaveChanges();

            //Console.WriteLine($"Order created: {order.Id}");


            //// ======================================================
            //// TEST 6: INSERT ORDER ITEMS
            //// Many-to-Many through OrderItem
            //// ======================================================

            //var item1 = new OrderItem
            //{
            //    OrderId = order.Id,
            //    ProductId = laptop.Id,
            //    Quantity = 1,
            //    UnitPrice = laptop.Price
            //};

            //var item2 = new OrderItem
            //{
            //    OrderId = order.Id,
            //    ProductId = mouse.Id,
            //    Quantity = 2,
            //    UnitPrice = mouse.Price
            //};

            //context.orderItems.AddRange(item1, item2);
            //context.SaveChanges();

            //Console.WriteLine("Order items created.");


            //// ======================================================
            //// TEST 7: READ CUSTOMER
            //// ======================================================

            //var foundCustomer = context.customers
            //    .FirstOrDefault(c => c.Id == customer.Id);

            //Console.WriteLine("\nCustomer:");
            //Console.WriteLine($"Id: {foundCustomer.Id}");
            //Console.WriteLine($"Name: {foundCustomer.Name}");
            //Console.WriteLine($"Email: {foundCustomer.Email}");


            //// ======================================================
            //// TEST 8: READ CUSTOMER + PROFILE
            //// One-to-One
            //// ======================================================

            //var customerWithProfile = context.customers
            //    .Include(c => c.customerProfile)
            //    .FirstOrDefault(c => c.Id == customer.Id);

            //Console.WriteLine("\nCustomer Profile:");

            //Console.WriteLine($"Customer: {customerWithProfile.Name}");
            //Console.WriteLine($"Phone: {customerWithProfile.customerProfile.Phone}");
            //Console.WriteLine(
            //    $"Birthdate: {customerWithProfile.customerProfile.Birthdate.ToShortDateString()}"
            //);


            //// ======================================================
            //// TEST 9: READ CUSTOMER + ORDERS
            //// One-to-Many
            //// ======================================================

            //var customerWithOrders = context.customers
            //    .Include(c => c.Orders)
            //    .FirstOrDefault(c => c.Id == customer.Id);

            //Console.WriteLine("\nOrders:");

            //foreach (var o in customerWithOrders.Orders)
            //{
            //    Console.WriteLine($"Order Id: {o.Id}");
            //    Console.WriteLine($"Order Date: {o.OrderDate}");
            //}


            //// ======================================================
            //// TEST 10: READ ORDER + CUSTOMER + ORDER ITEMS
            //// ======================================================

            //var orderDetails = context.orders
            //    .Include(o => o.Customer)
            //    .Include(o => o.OrderItems)
            //    .FirstOrDefault(o => o.Id == order.Id);

            //Console.WriteLine("\nOrder Details:");

            //Console.WriteLine($"Order Id: {orderDetails.Id}");
            //Console.WriteLine($"Customer: {orderDetails.Customer.Name}");

            //foreach (var item in orderDetails.OrderItems)
            //{
            //    Console.WriteLine(
            //        $"Product Id: {item.ProductId}, " +
            //        $"Quantity: {item.Quantity}, " +
            //        $"Unit Price: {item.UnitPrice}"
            //    );
            //}


            //// ======================================================
            //// TEST 11: ORDER + ITEMS + PRODUCT
            //// ThenInclude
            //// ======================================================

            //var completeOrder = context.orders
            //    .Include(o => o.Customer)
            //    .Include(o => o.OrderItems)
            //        .ThenInclude(oi => oi.Product)
            //    .FirstOrDefault(o => o.Id == order.Id);

            //Console.WriteLine("\nComplete Order:");

            //Console.WriteLine($"Customer: {completeOrder.Customer.Name}");

            //foreach (var item in completeOrder.OrderItems)
            //{
            //    Console.WriteLine(
            //        $"Product: {item.Product.Name}, " +
            //        $"Quantity: {item.Quantity}, " +
            //        $"Price: {item.UnitPrice}"
            //    );
            //}


            //// ======================================================
            //// TEST 12: CALCULATE ORDER TOTAL
            //// ======================================================

            //decimal total = completeOrder.OrderItems
            //    .Sum(item => item.Quantity * item.UnitPrice);

            //Console.WriteLine($"\nOrder Total: {total}");


            //// ======================================================
            //// TEST 13: UPDATE PRODUCT
            //// ======================================================

            //var productToUpdate = context.products
            //    .FirstOrDefault(p => p.Id == mouse.Id);

            //productToUpdate.Price = 30;

            //context.SaveChanges();

            //Console.WriteLine("\nProduct price updated.");


            //// ======================================================
            //// TEST 14: UPDATE CUSTOMER
            //// ======================================================

            //var customerToUpdate = context.customers
            //    .FirstOrDefault(c => c.Id == customer.Id);

            //customerToUpdate.Name = "Samy Nagy";

            //context.SaveChanges();

            //Console.WriteLine("Customer updated.");


            //// ======================================================
            //// TEST 20: SELECT / PROJECTION
            //// ======================================================

            //var productList = context.products
            //    .Select(p => new
            //    {
            //        p.Name,
            //        p.Price
            //    })
            //    .ToList();

            //Console.WriteLine("\nProduct List:");

            //foreach (var product in productList)
            //{
            //    Console.WriteLine(
            //        $"{product.Name} - {product.Price}"
            //    );
            //}


            var order = context.orderItems.All(oi => oi.Quantity > 1);


        }
    }
}
