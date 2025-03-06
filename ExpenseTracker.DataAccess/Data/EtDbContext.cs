using AppNtier.Entities.Models;
using ExpenseTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class EtDbContext : DbContext
{
    public EtDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<TransactionOf> Transactions { get; set; }

}
