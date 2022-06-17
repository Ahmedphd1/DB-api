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
    public class deliverytest
    {

        private readonly deliverycontroller deliverycontroller;
        private readonly Mock<ideliveryrepo> ideliveryrepo = new();

        public deliverytest()
        {
            deliverycontroller = new(ideliveryrepo.Object);
        }

        [Fact]
        public void delete_ok()
        {
            delivery mydelivery = new();

            ideliveryrepo.Setup(x => x.delete(4)).ReturnsAsync(mydelivery);

            var result = deliverycontroller.Deletedelivery(4);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_ok()
        {
            delivery mydelivery = new();

            ideliveryrepo.Setup(x => x.update(4, mydelivery)).ReturnsAsync(mydelivery);

            var result = deliverycontroller.Updatedelivery(mydelivery);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void delete_notfound()
        {
            delivery mydelivery = new();

            ideliveryrepo.Setup(x => x.delete(1000000)).ReturnsAsync(mydelivery);

            var result = deliverycontroller.Deletedelivery(100000000);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_notfound()
        {
            delivery mydelivery = new();

            ideliveryrepo.Setup(x => x.update(1000000, mydelivery)).ReturnsAsync(mydelivery);

            var result = deliverycontroller.Updatedelivery(mydelivery);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }
    }
}
