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
    public class paymenttest
    {

        private readonly paymentcontroller paymentcontroller;
        private readonly Mock<ipaymentrepo> ipaymentrepo = new();

        public paymenttest()
        {
            paymentcontroller = new(ipaymentrepo.Object);
        }

        [Fact]
        public void delete_ok()
        {
            payment mypayment = new();

            ipaymentrepo.Setup(x => x.delete(4)).ReturnsAsync(mypayment);

            var result = paymentcontroller.deletepayment(4);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_ok()
        {
            payment mypayment = new();

            ipaymentrepo.Setup(x => x.update(4, mypayment)).ReturnsAsync(mypayment);

            var result = paymentcontroller.updatepayment(mypayment);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void delete_notfound()
        {
            payment mypayment = new();

            ipaymentrepo.Setup(x => x.delete(1000000)).ReturnsAsync(mypayment);

            var result = paymentcontroller.deletepayment(100000000);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_notfound()
        {
            payment mypayment = new();

            ipaymentrepo.Setup(x => x.update(1000000, mypayment)).ReturnsAsync(mypayment);

            var result = paymentcontroller.updatepayment(mypayment);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }
    }
}
