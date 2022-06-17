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
    public class ordertest
    {

        private readonly ordercontroller ordercontroller;
        private readonly Mock<iordersrepo> iorderrepo = new();

        public ordertest()
        {
            ordercontroller = new(iorderrepo.Object);
        }

        [Fact]
        public void delete_ok()
        {
            orders myorder = new();

            iorderrepo.Setup(x => x.delete(4)).ReturnsAsync(myorder);

            var result = ordercontroller.Deleteorder(4);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_ok()
        {
            orders myorder = new();

            iorderrepo.Setup(x => x.update(1, myorder)).ReturnsAsync(myorder);

            var result = ordercontroller.updateorder(myorder);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void delete_notfound()
        {
            orders myorder = new();

            iorderrepo.Setup(x => x.delete(1000000)).ReturnsAsync(myorder);

            var result = ordercontroller.Deleteorder(100000000);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_notfound()
        {
            orders myorder = new();

            iorderrepo.Setup(x => x.update(1000000, myorder)).ReturnsAsync(myorder);

            var result = ordercontroller.updateorder(myorder);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }
    }
}
