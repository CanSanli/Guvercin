using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuvercinApp.Models
{
    public class ProfileViewModel
    {
        public Kullanici Kullanici { get; set; }
        public BireyselKullanici BireyselKullanici { get; set; }
        public KurumsalKullanici KurumsalKullanici { get; set; }
    }
}