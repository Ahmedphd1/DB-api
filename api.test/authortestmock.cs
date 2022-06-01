// CartControllerTest.cs

using System;
using dblibrary;
using dblibrary.database;
using Moq;
using NUnit.Framework;
using dbcontroller.Controllers;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test
{
    public class Tests
    {
        private authorcontroller controller;
        private Mock<IAuthorRepository> authormock;
        private List<user> authors;

        [SetUp]
        public void Setup()
        {

            authormock = new Mock<IAuthorRepository>();
            var authoritemsmock = new Mock<user>();

            authoritemsmock.Setup(item => item.authorid).Returns(10);

            authors = new List<user>()
          {
              authoritemsmock.Object
          };

            authormock.Setup(c => c.getAllAuthors()).Returns((Task<List<user>>)authors.AsEnumerable());

            controller = new authorcontroller(authormock.Object);
        }

        [Test]
        public void ShouldReturnCharged()
        {
            authormock.Setup(p => p.getAllAuthors()).Returns((Task<List<user>>)authors.AsEnumerable());

            // act
            var result = controller.getallauthors();

            // assert
            // myInterfaceMock.Verify((m => m.DoesSomething()), Times.Once());
            authormock.Verify(s => s.getAllAuthors(), Times.Once());

            Assert.AreEqual(typeof(user), (result.Result as List<user>)[0].GetType());
        }

        [Test]
        public void ShouldReturnNotCharged()
        {
            authormock.Setup(p => p.getAllAuthors()).Returns((Task<List<user>>)authors.AsEnumerable());

            // act
            var result = controller.getallauthors();

            // assert
            // myInterfaceMock.Verify((m => m.DoesSomething()), Times.Once());
            authormock.Verify(s => s.getAllAuthors(), Times.Once());

            Assert.AreEqual(null, (result.Result as List<user>)[0]);
        }
    }
}