using Entities.Concrete;
using System.Collections.Generic;

namespace WebAPI.Helper
{
  public class Car
  {
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public int ColorId { get; set; }
    public string ColorName { get; set; }
    public int MinFindexScore { get; set; }
    public string ModelName { get; set; }
    public int ModelYear { get; set; }
    public decimal DailyPrice { get; set; }
    public string Description { get; set; }
    public List<CarImage> CarImages { get; set; }
  }
}
