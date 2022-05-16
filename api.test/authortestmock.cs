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
        private List<author> authors;

        [SetUp]
        public void Setup()
        {

            authormock = new Mock<IAuthorRepository>();
            var authoritemsmock = new Mock<author>();

            authoritemsmock.Setup(item => item.authorid).Returns(10);

            authors = new List<author>()
          {
              authoritemsmock.Object
          };

            authormock.Setup(c => c.getAllAuthors()).Returns((Task<List<author>>)authors.AsEnumerable());

            controller = new authorcontroller(authormock.Object);
        }

        [Test]
        public void ShouldReturnCharged()
        {
            authormock.Setup(p => p.getAllAuthors()).Returns((Task<List<author>>)authors.AsEnumerable());

            // act
            var result = controller.getallauthors();

            // assert
            // myInterfaceMock.Verify((m => m.DoesSomething()), Times.Once());
            authormock.Verify(s => s.getAllAuthors(), Times.Once());

            Assert.AreEqual(typeof(author), (result.Result as List<author>)[0].GetType());
        }

        [Test]
        public void ShouldReturnNotCharged()
        {
            authormock.Setup(p => p.getAllAuthors()).Returns((Task<List<author>>)authors.AsEnumerable());

            // act
            var result = controller.getallauthors();

            // assert
            // myInterfaceMock.Verify((m => m.DoesSomething()), Times.Once());
            authormock.Verify(s => s.getAllAuthors(), Times.Once());

            Assert.AreEqual(null, (result.Result as List<author>)[0]);
        }
    }
}