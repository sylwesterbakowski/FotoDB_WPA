using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Builder
{
    public interface IPlanWystawyBuilder
    {
        void BuildFotoEksponat();
        void BuildObrazEksponat();
        void BuildRzezbaEksponat();
        void BuildMonetaEksponat();

        PlanWystawy GetPlanWystawy();
    }
}
