using FotoDB_WPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Builder
{
    public class PermanentPlanWystawyBuilder : IPlanWystawyBuilder
    {
        public PlanWystawy PlanWystawy { get; set; } = new PlanWystawy();
        public PermanentPlanWystawyBuilder()
        {
            this.Reset();
        }

        private void Reset()
        {
            PlanWystawy = new PlanWystawy() { Name = "Ekspozycja stała", Price = 30 };
        }
        public void BuildFotoEksponat()
        {
            PlanWystawy.AddEksponat(new Eksponat() { Title = "Foto", Value = "55 szt." });
        }

        public void BuildMonetaEksponat()
        {
            PlanWystawy.AddEksponat(new Eksponat() { Title = "Moneta", Value = "234 szt." });
        }

        public void BuildObrazEksponat()
        {
            PlanWystawy.AddEksponat(new Eksponat() { Title = "Obraz", Value = "5 szt." });
        }

        public void BuildRzezbaEksponat()
        {
            PlanWystawy.AddEksponat(new Eksponat() { Title = "Rzeźba", Value = "1 szt." });
        }

        public PlanWystawy GetPlanWystawy()
        {
            PlanWystawy result = PlanWystawy;

            this.Reset();

            return result;
        }
    }
}
