using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Linq;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        //[SecuredOperation("admin,creditCard.all,creditCard.get,customer")]
        public IDataResult<CreditCard> Get(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
        {
            var creditCard = GetCreditCardByCardInfo(cardNumber, expireYear, expireMonth, cvc, cardHolderFullName);
            if (creditCard != null)
            {
                return new SuccessDataResult<CreditCard>(creditCard);
            }
            return new ErrorDataResult<CreditCard>(null, Messages.CreditCardNotValid);
        }

        
        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            var creditCard = _creditCardDal.Get(c => c.Id == creditCardId);
            if (creditCard != null)
            {
                return new SuccessDataResult<CreditCard>(creditCard, Messages.CreditCardListed);
            }

            return new ErrorDataResult<CreditCard>(null, Messages.CreditCardNotFound);
        }


      [CacheRemoveAspect("ICreditCardService.Get")]
      public IResult Add(CreditCard creditCard)
        {

          var rulesResult = BusinessRules.Run(CheckIfCardNumberExist(creditCard.CardNumber));
          if (rulesResult != null)
          {
             return rulesResult;
          }

          _creditCardDal.Add(creditCard);
     
          return new SuccessResult(Messages.CreditCardSaved);
    }


    //[SecuredOperation("admin,creditCard.all,creditCard.validate,customer")]
    [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Validate(CreditCard creditCard)
        {
            var validateResult = GetCreditCardByCardInfo(creditCard.CardNumber, creditCard.ExpireYear, creditCard.ExpireMonth, creditCard.Cvc, creditCard.CardHolderFullName);
            if (validateResult != null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.CreditCardNotValid);
        }

        //[SecuredOperation("admin,creditCard.all,creditCard.update,customer")]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        private CreditCard GetCreditCardByCardInfo(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
        {
            return _creditCardDal.Get(c => c.CardNumber == cardNumber &&
                                           c.ExpireYear == expireYear &&
                                           c.ExpireMonth == expireMonth &&
                                           c.Cvc == cvc &&
                                           c.CardHolderFullName == cardHolderFullName.ToUpperInvariant()); // Convert Turkish characters into standard characters.
        }
    
        private IResult CheckIfCardNumberExist(string cardNumber)
        {
            var result = _creditCardDal.GetAll(b => Equals(b.CardNumber, cardNumber)).Any();
            if (result)
            {
                return new ErrorResult(Messages.CreditCardNotFound);
            }
            return new SuccessResult();
    }
  }
}
