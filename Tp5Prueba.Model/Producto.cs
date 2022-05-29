using System;

namespace Tp5Prueba.Model
{
    public class Producto
    {
        private double margenGanacia;
        private double precioFinal;
        public int Codigo { get; set; }
        public string Descripcion { get; set; } = "";
        public double CostoSinIva { get; set; } = 0;
        public double PorcentajeIva { get; set; } = 0;
        public double CostoConIva
        {
            get { return CostoSinIva + (CostoSinIva * PorcentajeIva); }
        }
        public double MargenGanancia
        {
            get { return margenGanacia; }
            set
            {
                precioFinal = CostoConIva + (CostoConIva * value);
                margenGanacia = value;
            }
        }
        public double PrecioFinal
        {
            get { return precioFinal; }
            set 
            { 
                margenGanacia = (precioFinal - CostoConIva) / CostoConIva;
                precioFinal = value;
            }
        }
        public int Existencias { get; set; } = 0;
        public Estado Estado { get; set; }
    }
}
