using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuvercinApp.Models
{
    public class RegViewModel
    {
        public IndividualMember IndividualMember { get; set; }
        public List<HouseholdMember> HouseholdMembers { get; set; }
    }
}