using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PostMarkInbound.Models
{
    public class PostmarkContext: DbContext
    {

        public PostmarkContext() : base("PostMarkInbox")
        { }

        public DbSet<PMInboundMessage> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}