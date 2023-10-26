using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
  public interface IReviewService
  {
    IDataResult<List<Review>> GetAll();
    IDataResult<Review> GetReviewById(int reviewId);
    IDataResult<List<Review>> GetReviewsByCarId(int carId);
    IDataResult<List<Review>> GetReviewsByCustomerId(int customerId);
    IResult Add(Review review);
    IResult Update(Review review);
    IResult Delete(int reviewId);
  }
}
