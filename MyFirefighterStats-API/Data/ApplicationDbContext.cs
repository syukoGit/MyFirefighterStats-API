// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="ApplicationDbContext.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API" file="ApplicationDbContext.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Data;

using Microsoft.EntityFrameworkCore;
using MyFirefighterStats.API.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PaySlip> PaySlips { get; set; }
}
