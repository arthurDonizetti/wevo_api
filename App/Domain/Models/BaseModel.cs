using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
  public abstract class BaseModel
  {
    [Key]
    public Guid Id { get; set; }
    private DateTime? _creteAt;
    public DateTime? CreateAt
    {
      get { return _creteAt; }
      set { _creteAt = value ?? DateTime.UtcNow; }
    }
    public DateTime? UpdateAt { get; set; }
  }
}
