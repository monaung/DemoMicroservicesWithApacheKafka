using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.OrderServices;
using Shared;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet("start-consuming-service")]
        public async Task<IActionResult> StartConsumingService()
        {
            await orderService.StartConsumingService();
            return NoContent();
        }

        [HttpGet("get-products")]
        public IActionResult GetProducts()
        {
            return Ok(orderService.GetProducts());
        }

        [HttpPost("add-order")]
        public IActionResult AddOrder(Order order)
        {
            orderService.AddOrder(order);
            return Ok("Order placed");
        }

        [HttpGet("order-summary")]
        public IActionResult GetOrderSummary() => Ok(orderService.GetOrderSummary());
    }
}
