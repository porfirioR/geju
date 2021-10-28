using System.Collections.Generic;

namespace GeJu.Back.Test.Models
{
    public class PdfDocumentRequest
    {
        public byte[] Template { get; set; }
        public IEnumerable<PdfFormData> FormData { get; set; }
    }
}
