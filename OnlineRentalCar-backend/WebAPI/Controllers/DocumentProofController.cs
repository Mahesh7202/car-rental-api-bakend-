using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DocumentProofsController : ControllerBase
    {
        private readonly IDocumentProofService _documentProofService;

        public DocumentProofsController(IDocumentProofService documentProofService)
        {
            _documentProofService = documentProofService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _documentProofService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _documentProofService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] DocumentProof documentProof, [FromForm] IFormFile file, [FromForm] int userId)
        {
            var result = _documentProofService.Add(documentProof, file, userId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm] DocumentProof documentProof, [FromForm] IFormFile file)
        {
            var result = _documentProofService.Update(documentProof, file);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(DocumentProof documentProof)
        {
            var result = _documentProofService.Delete(documentProof);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _documentProofService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
