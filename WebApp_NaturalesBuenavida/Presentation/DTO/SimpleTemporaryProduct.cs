using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.DTO
{
    [Serializable]
    public class SimpleTemporaryProduct
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
}