using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal= productDal;
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);  
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x=>x.ProductId==id));
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result,Messages.ProductListed);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);    
            return new SuccessResult(Messages.ProductUpdated);  
        }
    }
}
