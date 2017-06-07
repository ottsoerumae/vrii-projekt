using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //                                           Tühja interface'i on tore täita :D
    public class CooperationContext : DbContext, ICooperationContext //Sellel klassil on juba otsene seos EF'ga
    {
        //Luuakse AB'sse tabel (DbSet tähendab alati tabelit)
        public DbSet<Person> People { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }
        public DbSet<Voting> Votings { get; set; }
        public DbSet<ApartmentOwnersVote> ApartmentOwnersVotes { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<PossibleVote> PossibleVotes { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ApartmentsService> ApartmentsServices { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceRow> InvoiceRows { get; set; }

        //protected override void OnModelCreating(DbModelBuilder mB)
        //{
        //    mB.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //}

        public CooperationContext(): base("name=CoopSQL")
        {

        }
    }
}
