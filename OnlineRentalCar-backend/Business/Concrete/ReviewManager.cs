using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
  public class ReviewManager : IReviewService
  {
    private readonly IReviewDal _reviewDal;

    public ReviewManager(IReviewDal reviewDal)
    {
      _reviewDal = reviewDal;
    }

    public IDataResult<List<Review>> GetAll()
    {
      // Implement the logic to get all reviews from the data access layer
      var reviews = _reviewDal.GetAll();
      if (reviews.Count > 0)
      {
        return new SuccessDataResult<List<Review>>(reviews);
      }
      return new ErrorDataResult<List<Review>>("No reviews found.");
    }

    public IDataResult<Review> GetReviewById(int reviewId)
    {
      // Implement the logic to get a review by its ID from the data access layer
      var review = _reviewDal.Get(r => r.ReviewId == reviewId);
      if (review != null)
      {
        return new SuccessDataResult<Review>(review);
      }
      return new ErrorDataResult<Review>("Review not found.");
    }

    public IDataResult<List<Review>> GetReviewsByCarId(int carId)
    {
      // Implement the logic to get reviews for a specific car by its ID from the data access layer
      var reviews = _reviewDal.GetAll(r => r.CarId == carId);
      if (reviews.Count > 0)
      {
        return new SuccessDataResult<List<Review>>(reviews);
      }
      return new ErrorDataResult<List<Review>>("No reviews found for the specified car.");
    }

    public IDataResult<List<Review>> GetReviewsByCustomerId(int customerId)
    {
      // Implement the logic to get reviews submitted by a specific customer by their ID from the data access layer
      var reviews = _reviewDal.GetAll(r => r.CustomerId == customerId);
      if (reviews.Count > 0)
      {
        return new SuccessDataResult<List<Review>>(reviews);
      }
      return new ErrorDataResult<List<Review>>("No reviews found for the specified customer.");
    }

    public IResult Add(Review review)
    {
      // Implement the logic to add a new review using the data access layer
      // You can perform validation or business rules here before adding the review
      _reviewDal.Add(review);
      return new SuccessResult("Review added successfully.");
    }

    public IResult Update(Review review)
    {
      // Implement the logic to update an existing review using the data access layer
      // You can perform validation or business rules here before updating the review
      _reviewDal.Update(review);
      return new SuccessResult("Review updated successfully.");
    }

    public IResult Delete(int reviewId)
    {
      // Implement the logic to delete a review by its ID using the data access layer
      _reviewDal.Delete(new Review { ReviewId = reviewId });
      return new SuccessResult("Review deleted successfully.");
    }
  }
}
