using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Tests
{
    [TestClass()]
    public class DepartmentTests
    {
        Department A, B, C;
        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            A = new Department("TestA", "1234");
            B = new Department("TestB", "1234");
            C = new Department("TestA", "4321");
        }

        // Test Equals
        [TestMethod()]
        public void EqualsTest()
        {
            Assert.IsTrue(A.Equals(B));
            Assert.IsFalse(A.Equals(C));
        }

        // Test ToString
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(A.ToString(), "TestA");
            Assert.AreEqual(B.ToString(), "TestB");
            Assert.AreEqual(C.ToString(), "TestA");
        }
    }
}