using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmo_reporte
{
    public interface IFolio
    {
        IFolio Header();
        IFolio Footer();
        IFolio Detail();
        IFolio AddText(params object[] parametros);
    }
}
