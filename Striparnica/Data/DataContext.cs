using Microsoft.EntityFrameworkCore;
using Striparnica.Models;

namespace Striparnica.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Strip> Strip { get; set; }


    }
}
