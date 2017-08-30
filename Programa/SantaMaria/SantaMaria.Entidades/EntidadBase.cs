using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Entidades
{
    /// <summary>
    /// Clase que contiene los datos de auditoria que tienen que tener todas las entidades persitibles
    /// </summary>
    public class EntidadBase : SantaMaria.Entidades.IEntidadBase
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? ChangedOn { get; set; }

        public Guid ChangedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public Guid DeletedBy { get; set; }

        public bool Deleted { get; set; }

    }
}
