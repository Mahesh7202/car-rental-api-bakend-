using Entities.Concrete;

namespace WebAPI.Helper
{
  public class CarDetail
  {
    public Car Car { get; set; }
    public string RentDate { get; set; }
    public string ReturnDate { get; set; }
  }

}
