using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuvercinApp.Models
{
    public class EtModel
    {
        public YardimEt YardimEt { get; set; }
        public IEnumerable<YardimTalebi> YardimTalepleri { get; set; }
    }
}