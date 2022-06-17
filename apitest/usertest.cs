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
    public class usertest
    {

        private readonly usercontroller usercontroller;
        private readonly Mock<iuserrepo> iuserrepo = new();

        public usertest()
        {
            usercontroller = new(iuserrepo.Object);
        }

        [Fact]
        public void delete_ok()
        {
            user myuser = new();

            iuserrepo.Setup(x => x.delete(5)).ReturnsAsync(myuser);

            var result = usercontroller.deleteuser(5);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_ok()
        {
            user myuser = new();

            iuserrepo.Setup(x => x.update(5, myuser)).ReturnsAsync(myuser);

            var result = usercontroller.updateuser(myuser);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public void delete_notfound()
        {
            user myuser = new();

            iuserrepo.Setup(x => x.delete(1000000)).ReturnsAsync(myuser);

            var result = usercontroller.deleteuser(100000000);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }

        [Fact]
        public void update_notfound()
        {
            user myuser = new();

            iuserrepo.Setup(x => x.update(1000000, myuser)).ReturnsAsync(myuser);

            var result = usercontroller.updateuser(myuser);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(404, statuscoderesult.StatusCode);
        }
    }
}
