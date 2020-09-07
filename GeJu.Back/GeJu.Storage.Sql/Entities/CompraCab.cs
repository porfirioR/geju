using System;

namespace GeJu.Storage.Sql.Entities
{
    public class CompraCab: BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
    }
}
