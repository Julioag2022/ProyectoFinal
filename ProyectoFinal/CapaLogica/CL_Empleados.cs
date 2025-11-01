using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CL_Empleados
    {

        public double MtdSalarioBase(string TipoEmpleado)
        {
            if (TipoEmpleado == "Gerente") return 45000;
            if (TipoEmpleado == "Supervisor") return 20000;
            if (TipoEmpleado == "Soporte") return 15000;
            if (TipoEmpleado == "Contador") return 9000;
            return 0;
        }

    }
}
