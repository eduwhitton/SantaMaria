using System;
namespace SantaMaria.Entidades
{
    /// <summary>
    /// Interfaz que contiene los datos de auditoria
    /// </summary>
    public interface IEntidadBase
    {
        Guid ChangedBy { get; set; }
        DateTime? ChangedOn { get; set; }
        Guid CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        bool Deleted { get; set; }
        Guid DeletedBy { get; set; }
        DateTime? DeletedOn { get; set; }
        Guid Id { get; set; }
    }
}
