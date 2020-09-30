using System.ComponentModel.DataAnnotations;

namespace GeJu.Storage.Sql
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; }
    }
}
