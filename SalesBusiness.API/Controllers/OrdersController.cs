using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesBusiness.Api.Data;
using SalesBusiness.API.Data.Entities;
using System.Runtime.InteropServices;

namespace SalesBusiness.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly SalesBusinessContext _salesBusinessContext;
		public OrdersController(SalesBusinessContext salesBusinessContext)
		{
			_salesBusinessContext = salesBusinessContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			var orders = await _salesBusinessContext.Orders.ToListAsync();
			return Ok(orders);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetAsync(int id)
		{
			var order = await _salesBusinessContext.Orders.FindAsync(id);
			return Ok(order);
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync(Orders newOrder)
		{
			_salesBusinessContext.Orders.Add(newOrder);
			await _salesBusinessContext.SaveChangesAsync();
			return Ok(await _salesBusinessContext.Orders.ToListAsync());
		}
	}
}
