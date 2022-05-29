using System;
using System.Collections.Generic;
using System.Linq;
using Tp5Prueba.Model;

namespace Tp5Prueba.DataAccess
{
    public class ProductService : IProductService
    {
        public List<Producto> getAll()
        {
            return new List<Producto> {
                new Producto(){Codigo = 1, Descripcion = "Coca cola", CostoSinIva = 30,Estado = Estado.Activo, PorcentajeIva = 0.21, MargenGanancia = 0.1,Existencias = 10},
                new Producto(){Codigo = 2, Descripcion = "Empanadas", CostoSinIva = 30,Estado = Estado.Activo, PorcentajeIva = 0.21, MargenGanancia = 0.1,Existencias = 10},
                new Producto(){Codigo = 3, Descripcion = "Naranaja", CostoSinIva = 30,Estado = Estado.Activo, PorcentajeIva = 0.21, MargenGanancia = 0.1, Existencias = 10},
                new Producto(){Codigo = 4, Descripcion = "Pan", CostoSinIva = 30,Estado = Estado.Activo, PorcentajeIva = 0.21, MargenGanancia = 0.1, Existencias = 10},
                new Producto(){Codigo = 5, Descripcion = "Tortilla", CostoSinIva = 30,Estado = Estado.Activo, PorcentajeIva = 0.21, MargenGanancia = 0.1, Existencias = 10},
                new Producto(){Codigo = 6, Descripcion = "Hierba", CostoSinIva = 30,Estado = Estado.Activo, PorcentajeIva = 0.21, MargenGanancia = 0.1, Existencias = 0},
                new Producto(){Codigo = 7, Descripcion = "Azucar", CostoSinIva = 30,Estado = Estado.Activo, PorcentajeIva = 0.21, MargenGanancia = 0.1, Existencias = 10}
            };
        }

        public List<Producto> GetFiltered(Func<Producto,bool> expression)
        {
            return getAll().Where(expression).ToList();
        }

        public int GetNextId()
        {
            return getAll().Max(x => x.Codigo) + 1;
        }
    }
}
