//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class plato
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int menu { get; set; }
        public int categoria { get; set; }
    
        public virtual categoria categoria1 { get; set; }
        public virtual menu menu1 { get; set; }
    }
}
