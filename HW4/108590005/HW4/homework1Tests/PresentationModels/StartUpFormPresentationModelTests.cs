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
    public class StartUpFormPresentationModelTests
    {
        Model model;
        StartUpFormPresentationModel presentationModel;
        // Init
        [TestInitialize()]
        public void Initialize()
        {
            model = new Model(false);
            presentationModel = new StartUpFormPresentationModel(model);
        }

        // GetCourseSelectingPresentationModel Test
        [TestMethod()]
        public void GetCourseSelectingPresentationModelTest()
        {
            object m = presentationModel.GetCourseSelectingPresentationModel();
            Assert.AreEqual(typeof(CourseSelectingFormPresentationModel), m.GetType());
            Assert.AreEqual(model, ((CourseSelectingFormPresentationModel)m).GetModel());
        }

        // GetCourseManagementPresentationModel Test
        [TestMethod()]
        public void GetCourseManagementPresentationModelTest()
        {
            object m = presentationModel.GetCourseManagementPresentationModel();
            Assert.AreEqual(typeof(CourseManagementFormPresentationModel), m.GetType());
            Assert.AreEqual(model, ((CourseManagementFormPresentationModel)m).GetModel());
        }
    }
}