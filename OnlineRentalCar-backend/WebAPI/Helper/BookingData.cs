using Core.Entities.Concrete;
using System.Collections.Generic;

namespace WebAPI.Helper
{
  public class BookingData
  {
    public User User { get; set; }
    public List<CarDetail> CarDetails { get; set; }
    public OrderData OrderData { get; set; }
  }
}
