using Core.Entities;
using Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class DocumentProof : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string MimeType { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentType { get; set; }
        public  string InsuranceType { get; set; }
    }

}
