using System;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Domain.NormativeAspects.Models;

namespace programming_work_backend.Data;

public class DBContext : DbContext
{
    // Conection constructor
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {

    }
    // Models constructor
    public DbSet<NormativeAspect> NormativeAspects { get; set; }
}