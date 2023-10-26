using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IDocumentProofService
    {

            IDataResult<List<DocumentProof>> GetAll();
            IDataResult<DocumentProof> GetById(int documentProofId);
            IResult Add(DocumentProof documentProof, IFormFile file, int userId);
            IResult Update(DocumentProof documentProof, IFormFile file);
            IResult Delete(DocumentProof documentProof);
            IDataResult<List<DocumentProof>> GetByUserId(int userId);
        
    }

}
