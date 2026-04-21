using Microsoft.AspNetCore.Mvc;

using Walmart.Models;

namespace Walmart.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        public IActionResult Checkout()
        {
            if (cart.Lines.Count() == 0)
            {
                TempData["EmptyCartError"] = "Your cart is empty. Add some items before checking out.";
                return RedirectToAction("Index", "Cart", new { returnUrl = "/" });
            }
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToAction("Completed", new { orderId = order.OrderID });
            }
            else
            {
                return View(order);
            }
        }

        public IActionResult Completed(int orderId)
        {
            var order = repository.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null) return RedirectToAction("Index", "Home");
            return View(order);
        }

        public ViewResult Retrieve()
        {
            return View(repository.Orders.OrderByDescending(o => o.OrderID));
        }
    }
}
