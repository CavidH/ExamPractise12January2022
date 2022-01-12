﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPractise12January2022.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise12January2022.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<WhyChoose> WhyChooses { get; set; }
    }
}