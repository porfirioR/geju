using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeJu.Storage.Sql
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; }
    }
}
