using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmo_reporte
{
    class Program
    {
        static void Main(string[] args)
        {
            var Page = new CFolio();
           
            Page.AgregarTextoCentro("Ingrese el Nombre de la Empresa aqui mismo, esto tendra un salto de linea xd");
            Page.AgregarTextoCentro("Ingrese la Dirección de la Empresa aqui");
            Page.TextoIzquierda("Un Simple Texto");
            Page.AgregarLineas();
            Page.Header();
            Page.AddText("1", 10000, 20000, 10000, DateTime.Now.ToShortDateString());
            Page.AgregarLineas();
            Page.TextoDerecha("Total de la Venta Registrada: 10.000.000$");
            Console.WriteLine(Page);
            Console.ReadKey();
        }
    }
}
