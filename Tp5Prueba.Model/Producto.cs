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
            get { return Math.Round(margenGanacia,2); }
            set
            {
                precioFinal = CostoConIva + (CostoConIva * value);
                margenGanacia = value;
            }
        }
        public double PrecioFinal
        {
            get { return CostoConIva + (CostoConIva * margenGanacia); }
            set 
            { 
                margenGanacia = (value - CostoConIva) / CostoConIva;
                precioFinal = value;
            }
        }
        public int Existencias { get; set; } = 0;
        public Estado Estado { get; set; } = Estado.Activo;

        public bool Validar()
        {
            var result = true;
            if (Codigo <= 0) result = false;
            if (string.IsNullOrEmpty(Descripcion)) result = false;
            if (string.IsNullOrEmpty(Descripcion)) result = false;
            if (CostoSinIva <= 0) result = false;
            if (precioFinal <= 0) result = false;
            if (Existencias <= 0) result = false;
            if (Estado != Estado.Activo) result = false;
            return result;
        }
    }
}
