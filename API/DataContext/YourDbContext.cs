using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataContext
{
    public class YourDbContext : DbContext
    {
    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
    {
        TreeNodes = Set<TreeNode>();
        ExceptionLogs = Set<ExceptionLog>();
    }

    public DbSet<TreeNode> TreeNodes { get; set; }
    public DbSet<ExceptionLog> ExceptionLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Dodaj dowolne konfiguracje modeli, jeśli są potrzebne
    }
}

}