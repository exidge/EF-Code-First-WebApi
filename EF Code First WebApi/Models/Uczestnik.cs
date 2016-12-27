namespace EF_Code_First_WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Uczestnik
    {
        public int ID { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public bool takObiad { get; set; }

        public bool takNocleg { get; set; }

        public bool takOplata { get; set; }

        public DateTime dataPrzyjazdu { get; set; }

        public DateTime dataOdjazdu { get; set; }
    }
}
