using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuvercinApp.Models
{
    public class RegViewModel
    {
        public string RegistrationType { get; set; }
        public Kullanici Kullanici { get; set; }
        public BireyselKullanici BireyselKullanici { get; set; }
        public KurumsalKullanici KurumsalKullanici { get; set; }
    }

}