using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Models
{
    public class CennikPlansWystawy
    {
        public PlanWystawy PermanentPlanWystawy { get; set; }
        public PlanWystawy TemporaryPlanWystawy { get; set; }
        public PlanWystawy CustomPlanWystawy { get; set; }
    }
}
