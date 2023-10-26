using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using System.Diagnostics;

namespace Business.Concrete
{
    public class DocumentProofManager : IDocumentProofService
    {
        private readonly IDocumentProofDal _documentProofDal;

        public DocumentProofManager(IDocumentProofDal documentProofDal)
        {
            _documentProofDal = documentProofDal;
        }

        [CacheAspect(10)]
        public IDataResult<List<DocumentProof>> GetAll()
        {
            return new SuccessDataResult<List<DocumentProof>>(_documentProofDal.GetAll(), Messages.DocumentProofsListed);
        }

        [CacheAspect(10)]
        public IDataResult<DocumentProof> GetById(int documentProofId)
        {
            return new SuccessDataResult<DocumentProof>(_documentProofDal.Get(d => d.Id == documentProofId), Messages.DocumentProofListed);
        }

        //[ValidationAspect(typeof(DocumentProofValidator))]
        [CacheRemoveAspect("IDocumentProofService.Get")]
        public IResult Add(DocumentProof documentProof, IFormFile file, int userId)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfDocumentProofLimitExceeded(userId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            documentProof.UserId = userId;
            documentProof.FilePath = imageResult.Message;
            documentProof.UploadDate = DateTime.Now;

            Trace.WriteLine("fffffffffffffffffffffffffffffffffffffff");

            Trace.WriteLine(documentProof.DocumentType);

            _documentProofDal.Add(documentProof);
            return new SuccessResult(Messages.DocumentProofAdded);
        }

    //    [ValidationAspect(typeof(DocumentProofValidator))]
        [CacheRemoveAspect("IDocumentProofService.Get")]
        public IResult Update(DocumentProof documentProof, IFormFile file)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfDocumentProofIdExist(documentProof.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var updatedDocumentProof = _documentProofDal.Get(d => d.Id == documentProof.Id);
            var result = FileHelper.Update(file, updatedDocumentProof.FilePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorUpdatingDocumentProof);
            }

            documentProof.FilePath = result.Message;
            documentProof.UploadDate = DateTime.Now;

            _documentProofDal.Update(documentProof);
            return new SuccessResult(Messages.DocumentProofUpdated);
        }

        [CacheRemoveAspect("IDocumentProofService.Get")]
        public IResult Delete(DocumentProof documentProof)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfDocumentProofIdExist(documentProof.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedDocumentProof = _documentProofDal.Get(d => d.Id == documentProof.Id);
            var result = FileHelper.Delete(deletedDocumentProof.FilePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorDeletingDocumentProof);
            }

            _documentProofDal.Delete(deletedDocumentProof);
            return new SuccessResult(Messages.DocumentProofDeleted);
        }

        [CacheRemoveAspect("IDocumentProofService.Get")]
        public IResult DeleteAllImagesOfCarByCarId(int userId)
        {
            var deletedDocumentProofs = _documentProofDal.GetAll(d => d.UserId == userId);
            if (deletedDocumentProofs == null)
            {
                return new ErrorResult(Messages.NoDocumentProofs);
            }

            foreach (var deletedDocumentProof in deletedDocumentProofs)
            {
                _documentProofDal.Delete(deletedDocumentProof);
                FileHelper.Delete(deletedDocumentProof.FilePath);
            }

            return new SuccessResult(Messages.DocumentProofsDeleted);
        }

        public IDataResult<List<DocumentProof>> GetByUserId(int userId)
        {
            var documentProofs = _documentProofDal.GetAll(d => d.UserId == userId);
            if (documentProofs != null && documentProofs.Any())
            {
                return new SuccessDataResult<List<DocumentProof>>(documentProofs, Messages.DocumentProofsListedByUserId);
            }

            return new ErrorDataResult<List<DocumentProof>>(null, Messages.NoDocumentProofsForUser);
        }


        // Business Rules

        private IResult CheckIfDocumentProofLimitExceeded(int userId)
        {
            int result = _documentProofDal.GetAll(d => d.UserId == userId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.DocumentProofLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfDocumentProofIdExist(int documentProofId)
        {
            var result = _documentProofDal.GetAll(d => d.Id == documentProofId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.DocumentProofIdNotExist);
            }
            return new SuccessResult();
        }
    }
}
