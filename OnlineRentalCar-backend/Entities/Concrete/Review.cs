using System;
using Core.Entities;

namespace Entities.Concrete
{
  public class Review : IEntity
  {
    public int ReviewId { get; set; }
    public string displayName { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public string ReviewContent { get; set; }
    public int Rating { get; set; }
    public DateTime ReviewDate { get; set; }
    
  }
}
