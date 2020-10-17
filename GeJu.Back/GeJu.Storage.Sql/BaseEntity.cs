using System;
using System.ComponentModel.DataAnnotations;

namespace GeJu.Sql
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
