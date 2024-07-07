using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuvercinApp.Models
{
    public class IslemlerViewModel
    {
        public List<YardimEt> GelenTalepler { get; set; }
        public List<YardimEt> OnaylananTalepler { get; set; }
        public List<YardimEt> TamamlananTalepler { get; set; }
        public List<YardimEt> TamamlanamayanTalepler { get; set; }
        public List<YardimEt> ReddedilenTalepler { get; set; }
        public List<YardimEt> ButunTalepler { get; set; }
    }
}