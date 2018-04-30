using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGuys.Models;
using PizzaGuys.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PizzaGuys.Controllers
{
    public class HomeController : BaseController
    {

        private int x = 8;

        private PizzaGuysContext _context;
        public HomeController(PizzaGuysContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult PizzaHome()
        {
            return View();
        }

        [Authorize]
        public IActionResult SizeAndToppingPicker()
        {
            var toppings = _context.ToppingInfo.ToList();
            var model = new ToppingViewModel
            {
                Toppings = new string[toppings.Count]
            };

            int i = 0;
            foreach (var topping in toppings)
            {

                model.Toppings[i] = topping.Name;

                i++;

            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SizeAndToppingPick()
        {

            var order = new Order
            {
                CustomerId = GetLoggedInUser().CustomerId,
                EmployeeId = 2,
                DeliveryStatus = 2

            };
            _context.Order.Add(order);

            SetOrder(order);

            var toppingInfo = new List<ToppingInfo>();
            for (int i = 2; i <= 4; i++)
            {
                var top = _context.ToppingInfo.Where(t => t.Id == i).SingleOrDefault();
                toppingInfo.Add(top);
            }
            foreach (var top in toppingInfo)
            {
                var topping = new Toppings
                {
                    OrderId = order.OrderId,
                    ToppingId = top.Id
                };
                _context.Toppings.Add(topping);
            }


            //var toppings = _context.Toppings.Where(t => t.OrderId == order.OrderId).ToList();
            //foreach (var topping in toppings)
            //{
            //    order.Toppings.Add(topping);
            //}

            //_context.Update(order);

            _context.SaveChanges();

            return RedirectToAction("MakeAPayment");

        }

        public IActionResult MakeAPayment()
        {
            return View();
        }

        public IActionResult Paid()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Pay()
        {
            var cardType = new CardType
            {
                Type = "Card"
            };
            _context.CardType.Add(cardType);


            var cardInfo = new CardInfo
            {
                CardNumber = 4060425,
                CardTypeId = 1,
                Ccv = 900

            };
            _context.CardInfo.Add(cardInfo);

            var paymentOption = new PaymentOption
            {
                CardInfoId = cardInfo.Id,
                Options = "Card"
            };
            _context.PaymentOption.Add(paymentOption);

            var order = GetOrder().OrderId;
            var payment = new Payment
            {
                CustomerId = GetLoggedInUser().CustomerId,
                OrderId = 53,
                PaymentOption = paymentOption.Id,
                Status = "OK(400)"


            };
            x++;
            _context.Payment.Add(payment);
            _context.SaveChanges();


            return RedirectToAction(nameof(Paid));
        }
    }
}
