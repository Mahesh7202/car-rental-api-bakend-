using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
      _reviewService = reviewService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _reviewService.GetAll();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
      var result = _reviewService.GetReviewById(id);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbycarid")]
    public IActionResult GetByCarId(int carId)
    {
      var result = _reviewService.GetReviewsByCarId(carId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbycustomerid")]
    public IActionResult GetByCustomerId(int customerId)
    {
      var result = _reviewService.GetReviewsByCustomerId(customerId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Review review)
    {
      var result = _reviewService.Add(review);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Review review)
    {
      var result = _reviewService.Update(review);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("delete")]
    public IActionResult Delete(int id)
    {
      var result = _reviewService.Delete(id);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
