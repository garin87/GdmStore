using GdmStore;
using GdmStore.Models;
using GdmStore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GgmStore.Tests
{
    public class ProductControllerTest 
    {
        ProductsController _productController;
        IBaseServices<Product> _baseService;
        DataContext _context;

        public ProductControllerTest()
        {
            _baseService = new BaseServiceFake();
            _productController = new ProductsController(_context);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //// Act
            //var okResult = _productController.GetAll();

            //// Assert
            //Assert.IsType<OkObjectResult>(okResult.Result);
        }
        //[Fact]
        //public void IndexReturnsAViewResultWithAListOfPhones()
        //{

        //// Arrange
        //var mock = new Mock<ProductService>();
        //mock.Setup(repo => repo.GetAll()).Returns(GetAll());
        //var controller = new ProductsController(mock.context);

        //// Act
        //var result = controller.GetAll();

        //// Assert
        //var viewResult = Assert.IsType<ViewResult>(result);
        //var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);
        //Assert.Equal(GetAll().Count, model.Count());
        //}

        //[Fact]
        //public void Get_WhenCalled_ReturnsAllItems()
        //{
        //    // Act
        //    var okResult = _productController.GetAll().Result as OkObjectResult;

        //    // Assert
        //    var items = Assert.IsType<List<Product>>(okResult.Value);
        //    Assert.Equal(3, items.Count);
        //}


    }
}
