using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCOMD_2._0
{
    public class feeding
    {
        public string Description { get; set; }  // Descripción de la transacción
        public int Quantity { get; set; }         // Cantidad total
        public decimal Grant { get; set; }       // Subvención o aporte económico
        public decimal Cash { get; set; }        // Efectivo disponible
    }
}
