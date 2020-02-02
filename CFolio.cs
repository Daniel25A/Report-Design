
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Marcelo.Reportes
{
    public class CFolio : IFolio
    {
        public StringBuilder Texto;
        private int A4Lines = 47;
        private int OfLines = 60;
        private int Extension = 100;
        private string LineType = "-";
        private string Border = "|";
        private Dictionary<string, int> Hojas = new Dictionary<string, int>();
        //Calcular aqui segun requerimientos, Recurden, La Suma de estas Variables siempre debe ser igual a el valor de la variable Extension
        int numL = 15, totalL = 20, entreaL = 20, cambioL = 20, fechaL = 25;
        public CFolio()
        {
            Texto = new StringBuilder();
            Hojas.Add("A4", A4Lines);
            Hojas.Add("OFICIO", OfLines);
        }
        //Sorry por repetir codigo aqui, pero no encuentro forma de crear un metodo y 
        //agregar el texto sin necesidad de tener el mismo codigo en AgregarTextoCentro y este metodo
        public void AgregarTexto(string texto)
        {
            var FinalText = string.Empty;
            var MaxLong = Extension;
            var TotalText = (int)0;
            if (texto.Length > MaxLong)
            {
                int x = (texto.Length / MaxLong);
                int Resto = 0;
                if (x > 0)
                {
                    if ((texto.Length % MaxLong) > 0)
                    {
                        Resto = (texto.Length % MaxLong);
                    }
                    for (int i = 0; i < x; i++)
                    {
                        FinalText += texto.Substring(TotalText, MaxLong);
                        Texto.AppendLine(FinalText);
                        FinalText = "";
                        TotalText += MaxLong;
                    }
                }
                FinalText += texto.Substring(TotalText, Resto);
                this.Texto.AppendLine(FinalText);
            }
            else
            {
                FinalText = texto;
                Texto.AppendLine(FinalText);
            }

        }
        public void AgregarTextoCentro(string texto,int Restar=0)
        {
            var FinalText = string.Empty;
            var TextAdd = string.Empty;
            var CorteMax = 70+Restar;
            var MaxLong = CorteMax;
            var TotalText = (int)0;
            if (texto.Length > MaxLong)
            {
                int x = (texto.Length / MaxLong);
                int Resto = 0;
                if (x > 0)
                {
                    if ((texto.Length % MaxLong) > 0)
                    {
                        Resto = (texto.Length % MaxLong);
                    }
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = CorteMax; j < Extension; j++)
                        {
                            FinalText += " ";
                        }
                        FinalText += texto.Substring(TotalText, MaxLong);
                        Texto.AppendLine(FinalText);
                        FinalText = "";
                        TotalText += MaxLong;
                    }
                }
                for (int j = CorteMax; j < Extension; j++)
                {
                    FinalText += " ";
                }
                FinalText += texto.Substring(TotalText, Resto);
                this.Texto.AppendLine(FinalText);

            }
            else
            {
                for (int i = CorteMax; i < Extension; i++)
                {
                    FinalText += " ";
                }
                FinalText += texto;
                Texto.AppendLine(FinalText);
            }

        }
        public void TextoIzquierda(string texto)
        {
            Texto.AppendLine(texto);
        }
        public void TextoDerecha(string texto)
        {
            var FinalText = string.Empty;
            for (int i = texto.Length; i < Extension; i++)
            {
                FinalText += " ";
            }
            FinalText += texto;
            Texto.AppendLine(FinalText);
        }
        public IFolio AddText(params object[] parametros)
        {
            AgregarLineas();
            string NumVenta = Border + (string)parametros[0];
            string Total = (parametros[1]).ToString(), Entrega = parametros[2].ToString();
            string Cambio = parametros[3].ToString(), Fecha = (string)parametros[4];
            string text = (string)parametros[0];

            var TextoCompleto = GetTextFormat(NumVenta, numL)
                + GetTextFormat(Total, totalL)
                + GetTextFormat(Entrega, entreaL)
                + GetTextFormat(Cambio, cambioL)
                + GetTextFormat(Fecha, fechaL);
            Texto.AppendLine(TextoCompleto
                );
            return this;
        }
        public void AgregarLineas()
        {
            string LineasText = string.Empty;
            for (int i = 0; i < Extension; i++)
            {
                LineasText += LineType;
            }
            Texto.AppendLine(LineasText);
        }
        private string GetTextFormat(string Text, int Maxtlengt)
        {
            if (Text.Length > Maxtlengt)
            {
                Text = Text.Substring(0, Maxtlengt - 3) + ".." + Border;
            }
            else if (Text.Length < Maxtlengt)
            {
                int longitud = Text.Length;
                for (int i = 0; i < (Maxtlengt - longitud) - 1; i++)
                {
                    Text += " ";
                }
                Text += Border;
            }
            else
            {
                Text = Text.Substring(0, Maxtlengt - 1) + Border;
            }
            return Text;
        }
        public override string ToString()
        {
            return Texto.ToString();
        }
        public IFolio Detail()
        {
            return this;
        }

        public IFolio Footer()
        {
            return this;
        }
        public void Longitud()
        {
            Console.WriteLine(this.Texto.ToString().Split('\n').Length);
        }
        public void Header2(StringBuilder parametro)
        {
            string num = Border + "NUM. VENTA";
            string tot = "TOT. VENTA";
            string entr = "ENT. VENTA";
            string cam = "CAMBIO. VENTA";
            string fech = "FECHA. VENTA";
            var TextoCompleto = GetTextFormat(num, numL)
                + GetTextFormat(tot, totalL)
                + GetTextFormat(entr, entreaL)
                + GetTextFormat(cam, cambioL)
                + GetTextFormat(fech, fechaL);
            parametro.AppendLine(TextoCompleto
              );
        }
        public void AgregarLineas2(StringBuilder parametro)
        {
            string LineasText = string.Empty;
            for (int i = 0; i < Extension; i++)
            {
                LineasText += LineType;
            }
            parametro.AppendLine(LineasText);
        }
        public IFolio Header()
        {
            string num = Border + "NUM. VENTA";
            string tot = "TOT. VENTA";
            string entr = "ENT. VENTA";
            string cam = "CAMBIO. VENTA";
            string fech = "FECHA. VENTA";
            var TextoCompleto = GetTextFormat(num, numL)
                + GetTextFormat(tot, totalL)
                + GetTextFormat(entr, entreaL)
                + GetTextFormat(cam, cambioL)
                + GetTextFormat(fech, fechaL);
            Texto.AppendLine(TextoCompleto
              );
            return this;
        }
        public async void Imprimir(string impresora,string Hoja)
        {
            int Lineas = Texto.ToString().Split('\n').Length;
            int MaxLineas = Hojas[Hoja.ToUpper()];
            int Paginas = 0;
            int Resto = 0;
            var Page = new StringBuilder();
            int Contador = 0;
            if (Lineas > MaxLineas)
            {
                Paginas = Lineas / MaxLineas;
                if (Lineas % MaxLineas > 0)
                    Resto = Lineas % MaxLineas;
                for (int i = 0; i < Paginas; i++)
                {
                    if (i > 0)
                    {
                        AgregarLineas2(Page);
                        Header2(Page);
                        AgregarLineas2(Page);
                    }
                    foreach(var x in Texto.ToString().Split('\n').Skip(Contador).Take(MaxLineas))
                    {
                        Page.AppendLine(x);
                    }
                    await Task.Run(() => RawPrinterHelper.SendStringToPrinter(impresora, Page.ToString()));
                    Contador += MaxLineas;
                    Page.Clear();
                }
                if (Resto > 0)
                {
                    AgregarLineas2(Page);
                    Header2(Page);
                    AgregarLineas2(Page);
                }
                foreach (var x in Texto.ToString().Split('\n').Skip(Contador).Take(Resto))
                {
                    Page.AppendLine(x);
                }
                await Task.Run(() => RawPrinterHelper.SendStringToPrinter(impresora, Page.ToString()));
            }
            else
            {
                await Task.Run(() => RawPrinterHelper.SendStringToPrinter(impresora, Texto.ToString()));
            }         
            Texto.Clear();
        }

        public class RawPrinterHelper
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false;

                di.pDocName = "Reporte Venta";
                di.pDataType = "RAW";


                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {

                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                       
                        if (StartPagePrinter(hPrinter))
                        {
                     
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }

                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;

                dwCount = szString.Length;

                pBytes = Marshal.StringToCoTaskMemAnsi(szString);

                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }
    }
}

