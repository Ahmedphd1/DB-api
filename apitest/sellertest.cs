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
    public class sellertest
    {

        private readonly sellercontroller sellercontroller;
        private readonly Mock<isellerrepo> isellerrepo = new();

        public sellertest()
        {
            sellercontroller = new(isellerrepo.Object);
        }

        [Fact]
        public void delete_ok()
        {
            seller myseller = new();

            isellerrepo.Setup(x => x.delete(4)).ReturnsAsync(myseller);

            var result = sellercontroller.deleteseller(4);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void delete_notfound()
        {
            seller myseller = new();

            isellerrepo.Setup(x => x.delete(1000000)).ReturnsAsync(myseller);

            var result = sellercontroller.deleteseller(100000000);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_ok()
        {
            seller myseller = new();

            isellerrepo.Setup(x => x.update(4, myseller)).ReturnsAsync(myseller);

            var result = sellercontroller.updateseller(myseller);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_notfound()
        {
            seller myseller = new();

            isellerrepo.Setup(x => x.update(1000000, myseller)).ReturnsAsync(myseller);

            var result = sellercontroller.updateseller(myseller);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }
    }
}
