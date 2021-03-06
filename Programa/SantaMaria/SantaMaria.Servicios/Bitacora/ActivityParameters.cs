﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMaria.Servicios.Bitacora
{
    /// <summary>
    /// Clase que contiene los parametros necesarios para un Log de Actividad
    /// </summary>
    public class ActivityParameters
    {
        public DateTime LogDate { get; set; }
        public string Activity { get; set; }
        public string Result { get; set; }
        public string IpAddress { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public Guid? ChangedBy { get; set; }
    }
}
