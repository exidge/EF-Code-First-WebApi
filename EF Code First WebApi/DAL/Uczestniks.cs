using EF_Code_First_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Code_First_WebApi.DAL
{
    public class UczestnicyKonferencji : DbContext
    {
        //public UczestnicyKonferencji() : base("EntityContext")
        //{

        //}
        public UczestnicyKonferencji() { }
        public UczestnicyKonferencji(string ConnectionString) : base(ConnectionString)
        {
            Database.SetInitializer<UczestnicyKonferencji>(null);
        }
        public DbSet<Uczestnik> Uczestnicy { get; set; }

    }
}