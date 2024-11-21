using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.Medilink.Data.Entity.Common;

public class BaseEntity
{
    [Required]
    [Column("id"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public virtual long Id { get; private set; }
}
