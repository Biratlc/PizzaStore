using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PizzaGuys.Models;

namespace PizzaGuys.Helper
{
    public static class SessionHelper
    {

        public static void SetSession(this ISession session, string key, object o)
        {
            var str = JsonConvert.SerializeObject(o, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }
            );
            session.SetString(key, str);
        }

        public static T GetSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value != null)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default(T);
        }

        public static Customer GetLoggedInUser(this ISession session)
        {
            return session.GetSession<Customer>("LoggedInUser");
        }

        public static Order GetOrder(this ISession session)
        {
            return session.GetSession<Order>("LoggedInOrder");
        }


        public static void SetLoggedInUser(this ISession session, Customer user)
        {
            session.SetSession("LoggedInUser", user);
        }

        public static void SetOrder(this ISession session, Order order)
        {
            session.SetSession("LoggedInOrder", order);
        }

    }
}
