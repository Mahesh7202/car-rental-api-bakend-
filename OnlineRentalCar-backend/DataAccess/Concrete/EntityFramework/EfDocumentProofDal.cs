using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDocumentProofDal : EfEntityRepositoryBase<DocumentProof, RentACarContext>, IDocumentProofDal
    { 
    }
}
