using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace homework1.Tests
{
    [TestClass()]
    public class ImportCourseProgressFormPresentationModelTests
    {
        Model model;
        ImportCourseProgressFormPresentationModel presentationModel;

        // Initialize
        [TestInitialize()]
        public void ImportCourseProgressFormPresentationModelTest()
        {
            model = new Model(false);
            presentationModel = new ImportCourseProgressFormPresentationModel(model);
        }

        // GetModel Test
        [TestMethod()]
        public void GetModelTest()
        {
            Assert.AreEqual(model, presentationModel.GetModel());
        }

        // StartCrawler Test
        [TestMethod()]
        public void StartCrawlerTest()
        {
            presentationModel.PropertyChanged += delegate { };
            Assert.AreEqual(0, presentationModel.Percentage);
            Assert.AreEqual("正在匯入課程...0%", presentationModel.ProgressInfo);
            presentationModel.StartCrawler();
        }
    }
}