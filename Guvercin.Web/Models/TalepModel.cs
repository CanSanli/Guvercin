using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuvercinApp.Models
{
    public class TalepModel
    {
        public YardimTalebi YardimTalebi { get; set; }
        public double Enlem { get; set; }
        public double Boylam { get; set; }
        public int YardimTuruId { get; set; }
    }
}
