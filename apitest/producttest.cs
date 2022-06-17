using System;
using Xunit;
using dbcontroller.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using dblibrary.repos;
using System.Threading.Tasks;
using dblibrary.models;
using Microsoft.AspNetCore.Mvc;

namespace apitest
{
    public class producttest
    {

        private readonly productcontroller productcontroller;
        private readonly Mock<iproductrepo> iproductrepo = new();

        public producttest()
        {
            productcontroller = new(iproductrepo.Object);
        }

        [Fact]
        public void delete_ok()
        {
            product myproduct = new();

            iproductrepo.Setup(x => x.delete(4)).ReturnsAsync(myproduct);

            var result = productcontroller.deleteproduct(4);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void delete_notfound()
        {
            product myproduct = new();

            iproductrepo.Setup(x => x.delete(1000000)).ReturnsAsync(myproduct);

            var result = productcontroller.deleteproduct(100000000);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_ok()
        {
            product myproduct = new();

            iproductrepo.Setup(x => x.update(1, myproduct)).ReturnsAsync(myproduct);

            var result = productcontroller.updateproduct(myproduct);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_notfound()
        {
            product myproduct = new();

            iproductrepo.Setup(x => x.update(1000000, myproduct)).ReturnsAsync(myproduct);

            var result = productcontroller.updateproduct(myproduct);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }
    }
}
