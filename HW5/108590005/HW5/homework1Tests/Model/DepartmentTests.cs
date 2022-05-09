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

        // Test Constructor
        [TestMethod()]
        public void ConstructorTest()
        {
            Department D = new Department(C);
            Assert.AreEqual(C.name, D.name);
            Assert.AreEqual(C.code, D.code);
        }

        // Test SetValueAs
        [TestMethod()]
        public void SetValueAsTest()
        {
            B.SetValueAs(new Department("department", "789"));
            Assert.AreEqual("department", B.name);
            Assert.AreEqual("789", B.code);
        }

        // Test IsAvailable
        [TestMethod()]
        public void IsAvaliableTest()
        {
            Department D = new Department("", "");
            Assert.IsTrue(A.IsAvailable());
            Assert.IsTrue(B.IsAvailable());
            Assert.IsTrue(C.IsAvailable());
            Assert.IsFalse(D.IsAvailable());
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

        // Delegate Event Test
        [TestMethod]
        public void PropertyChangedTest()
        {
            string changedPropertyName = string.Empty;
            Department department = new Department("Test", "1234");
            department.PropertyChanged += (sender, args) => changedPropertyName = args.PropertyName;
            department.name = "Name";
            Assert.AreEqual("name", changedPropertyName);
            department.code = "4321";
            Assert.AreEqual("code", changedPropertyName);
        }
    }
}