﻿using System.Reflection;
using Common.Model.Config;
using Infrastructure.ApiCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace shop_food_authen.Contexts
{
    public class EntityDBContext : DbContext
    {
        private readonly IOptions<AppConfig> _appSetting;
        public EntityDBContext(DbContextOptions<EntityDBContext> options, IOptions<AppConfig> appSetting) : base(options)
        {
            _appSetting = appSetting;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ServiceExtensions.OverWriteConnectString(_appSetting);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<AdminEntity> AdminEntities { get; set; }
    }
}