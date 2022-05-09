using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DrawingForm.Tests
{
    [TestClass]
    public class UITest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string FORM_NAME = "DrawingForm";
        private const string CANVAS = "_canvas";
        private const string RECTANGLE = "Rectangle";
        private const string ELLIPSE = "Ellipse";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "DrawingFormTests";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            //if (Path.GetFileName(solutionPath.TrimEnd('\\')) == "bin")
            //    solutionPath = Path.Combine(solutionPath, "..\\..\\");
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "DrawingForm.exe");
            _robot = new Robot(targetAppPath, FORM_NAME);
        }

        // Closes the launched program
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // Draw A Snow Man
        [TestMethod]
        public void DrawSnowMan()
        {
            // body
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 450, 380, 800, 730);
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 590, 430, 660, 500);
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 590, 530, 660, 600);
            // hands
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 430, 310, 450, 560);
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 800, 310, 820, 560);
            // face
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 525, 190, 725, 400);
            // eyes
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 565, 255, 605, 295);
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 645, 255, 685, 295);
            // mouth
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 605, 330, 645, 370);
            // hat
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 500, 130, 750, 230);
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 450, 230, 800, 250);
            // wait
            _robot.Sleep(1);
        }
    }
}
