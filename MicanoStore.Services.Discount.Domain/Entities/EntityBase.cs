using System.ComponentModel.DataAnnotations;

namespace MicanoStore.Services.Discount.Domain.Entities;

public class EntityBase
{
    [Key]
    public Guid Id { get; set; }
}