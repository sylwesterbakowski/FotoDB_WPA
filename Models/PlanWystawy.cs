using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Models
{
    public class PlanWystawy
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<Eksponat> Eksponats { get; set; } = new List<Eksponat>();

        public void AddEksponat(Eksponat eksponat)
        {
            Eksponats.Add(eksponat);
        }
    }
}
