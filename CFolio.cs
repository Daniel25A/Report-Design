
using System.Text;


namespace Algorithmo_reporte
{
    public class CFolio:IFolio
    {
        StringBuilder Texto;// 100,000,000
        int Extension = 100; //27,9,9,5
        string LineType = "-";
        string Border = "|";
        int numL = 15, totalL = 20, entreaL = 20, cambioL = 20, fechaL = 25;
        public CFolio()
        {
            Texto = new StringBuilder();
        }
        public void AgregarTextoCentro(string texto)
        {
            var FinalText = string.Empty;
            var TextAdd = string.Empty;
            var CorteMax = 70;
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
                        FinalText +=texto.Substring(TotalText, MaxLong);
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
            var FinalText = string.Empty;
            for (int i = texto.Length; i < Extension; i++)
            {
                FinalText += " ";
            }
            FinalText += texto;
            Texto.AppendLine(FinalText);
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
        public void Titulo()
        {
            string num = "NUM. VENTA";
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
            string Lineas = string.Empty;
            for (int i = 0; i < Extension; i++)
            {
                Lineas += LineType;
            }
            Texto.AppendLine(Lineas);
        }
        private string GetTextFormat(string Text,int Maxtlengt)
        {
            if (Text.Length > Maxtlengt)
            {
                Text = Text.Substring(0, Maxtlengt - 3) + ".."+ Border;
            }
            else if (Text.Length < Maxtlengt)
            {
                int longitud = Text.Length ;
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

        public IFolio Header()
        {
            return this;
        }
    }
}
