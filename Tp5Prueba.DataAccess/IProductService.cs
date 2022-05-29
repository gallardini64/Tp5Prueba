using System;
using System.Collections.Generic;
using System.Text;
using Tp5Prueba.Model;

namespace Tp5Prueba.DataAccess
{
    public interface IProductService
    {
        List<Producto> getAll();
        public List<Producto> GetFiltered(Func<Producto, bool> expression);
    }
}
