using Microsoft.AspNetCore.Mvc;
using PizzaGuys.Helper;
using PizzaGuys.Models;

namespace PizzaGuys.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        public Customer GetLoggedInUser()
        {
            return HttpContext.Session.GetLoggedInUser();
        }

        public Order GetOrder()
        {
            return HttpContext.Session.GetOrder();
        }

        public void SetLoggedInUser(Customer user)
        {
            SetSession("LoggedInUser", user);
        }

        public void SetOrder(Order order)
        {
            SetSession("LoggedInOrder", order);
        }

        public void SetSession(string key, object o)
        {
            HttpContext.Session.SetSession(key, o);
        }

        public T GetSession<T>(string key)
        {
            return HttpContext.Session.GetSession<T>(key);
        }
    }
}