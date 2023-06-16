using Manufacture.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.API.Data;
public class ManufactureContext : DbContext
{
	public ManufactureContext(DbContextOptions<ManufactureContext> options) : base(options)
	{

	}

	public DbSet<Products> Products { get; set; }
}
