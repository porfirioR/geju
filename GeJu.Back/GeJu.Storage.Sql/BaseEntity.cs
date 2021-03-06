﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeJu.Sql
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaModificado { get; set; }
    }
}
