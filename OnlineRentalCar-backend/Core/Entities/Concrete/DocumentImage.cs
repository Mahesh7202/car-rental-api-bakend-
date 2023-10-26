using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class DocumentImage : IEntity
    {
        public int Id { get; set; }
        public int DocumentProofId { get; set; } 
        public string ImagePath { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
