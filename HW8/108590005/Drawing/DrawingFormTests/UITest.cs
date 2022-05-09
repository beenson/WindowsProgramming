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
        private const string LINE = "Line";
        private const string CLEAR = "Clear";
        private const string UNDO = "Undo";
        private const string REDO = "Redo";
        private const string SAVE = "Save";
        private const string LOAD = "Load";
        private const string INFORMATION_LABEL = "_shapeInformationLabel";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "DrawingFormTests";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            //if (Path.GetFileName(solutionPath.TrimEnd('\\')) == "bin")
            //    solutionPath = Path.Combine(solutionPath, "..\\..\\");
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "shortcut.lnk");
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

        // Draw Ellipse
        [TestMethod]
        public void DrawEllipseTest()
        {
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 200, 200, 1000, 500);
            _robot.Click(CANVAS, 600, 350);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(200, 200, 1000, 500)");
        }

        // Draw Rectangle
        [TestMethod]
        public void DrawRectangleTest()
        {
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 200, 200, 1000, 500);
            _robot.Click(CANVAS, 600, 350);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(200, 200, 1000, 500)");
        }

        // Draw Line
        [TestMethod]
        public void DrawLineTest()
        {
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 500, 200, 1000, 500);
            _robot.ClickButton(LINE);
            _robot.Draw(CANVAS, 200, 200, 300, 1000);
            _robot.AssertEnable(LINE, false);
            _robot.Draw(CANVAS, 400, 100, 700, 300);
            _robot.AssertEnable(LINE, false);
            _robot.Draw(CANVAS, 200, 200, 700, 300);
            _robot.AssertEnable(LINE, true);
        }

        // Click Rectangle
        [TestMethod]
        public void ClickRectangleTest()
        {
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.Click(CANVAS, 99, 99);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 100, 100);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Click(CANVAS, 99, 301);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 100, 300);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Click(CANVAS, 301, 99);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 300, 100);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Click(CANVAS, 301, 301);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 300, 300);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
        }

        // Click Ellipse
        [TestMethod]
        public void ClickEllipseTest()
        {
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.Click(CANVAS, 100, 100);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 100, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 100, 300);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 200, 300);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 300, 300);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 300, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 300, 100);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 200, 100);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
        }

        // Click Clear
        [TestMethod]
        public void ClickClearTest()
        {
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 400, 200, 500, 300);
            _robot.ClickButton(LINE);
            _robot.Draw(CANVAS, 150, 150, 450, 250);
            _robot.ClickButton(CLEAR);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 450, 250);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.AssertEnable(UNDO, false);
            _robot.AssertEnable(REDO, false);
        }

        // Click Top Shape
        [TestMethod]
        public void ClickTopShapeTest()
        {
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.Click(CANVAS, 100, 100);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 100, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 100, 300);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 200, 300);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 300, 300);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 300, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 300, 100);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 200, 100);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "");
        }

        // Undo
        [TestMethod]
        public void UndoTest()
        {
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Draw(CANVAS, 200, 200, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(300, 300, 500, 500)");
            _robot.AssertEnable(UNDO, true);
            _robot.ClickButton(UNDO);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.AssertEnable(UNDO, true);
            _robot.ClickButton(UNDO);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "");
        }

        // Redo
        [TestMethod]
        public void RedoTest()
        {
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.Draw(CANVAS, 200, 200, 400, 400);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(300, 300, 500, 500)");
            _robot.AssertEnable(UNDO, true);
            _robot.ClickButton(UNDO);
            _robot.AssertEnable(UNDO, true);
            _robot.ClickButton(UNDO);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.AssertEnable(REDO, true);
            _robot.ClickButton(REDO);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(100, 100, 300, 300)");
            _robot.AssertEnable(REDO, true);
            _robot.ClickButton(REDO);
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 300, 300);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(300, 300, 500, 500)");
        }
        
        // Draw Test
        [TestMethod]
        public void AssertDrawShapesTest()
        {
            _robot.AssertEnable(UNDO, false);
            _robot.AssertEnable(REDO, false);
            // Draw
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.AssertEnable(UNDO, true);
            _robot.AssertEnable(REDO, false);
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 400, 200, 500, 300);
            _robot.ClickButton(LINE);
            _robot.Draw(CANVAS, 150, 150, 450, 250);
            // Assert
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 450, 250);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(400, 200, 500, 300)");
            // Undo Redo
            _robot.AssertEnable(UNDO, true);
            _robot.AssertEnable(REDO, false);
            _robot.ClickButton(UNDO);
            _robot.AssertEnable(UNDO, true);
            _robot.AssertEnable(REDO, true);
            _robot.ClickButton(UNDO);
            _robot.ClickButton(UNDO);
            _robot.AssertEnable(UNDO, false);
            _robot.AssertEnable(REDO, true);
            _robot.ClickButton(REDO);
            _robot.AssertEnable(UNDO, true);
            _robot.AssertEnable(REDO, true);
            // Clear
            _robot.ClickButton(CLEAR);
            _robot.AssertEnable(UNDO, false);
            _robot.AssertEnable(REDO, false);
        }

        // Move Test
        [TestMethod]
        public void MoveTest()
        {
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 400, 200, 500, 300);
            _robot.ClickButton(LINE);
            _robot.Draw(CANVAS, 150, 150, 450, 250);
            _robot.Click(CANVAS, 200, 200);
            _robot.Draw(CANVAS, 200, 200, 800, 500);
            _robot.Click(CANVAS, 800, 500);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(700, 400, 900, 600)");
        }

        // Save Load Test
        [TestMethod]
        public void SaveLoadTest()
        {
            // Draw Three Shapes
            _robot.ClickButton(ELLIPSE);
            _robot.Draw(CANVAS, 100, 100, 300, 300);
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 400, 200, 500, 300);
            _robot.ClickButton(LINE);
            _robot.Draw(CANVAS, 150, 150, 450, 250);
            // Save
            _robot.ClickButton(SAVE);
            _robot.ClickButtonById("1");
            _robot.Sleep(2);
            // Draw another shape
            _robot.ClickButton(RECTANGLE);
            _robot.Draw(CANVAS, 600, 300, 1000, 400);
            _robot.Click(CANVAS, 750, 350);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(600, 300, 1000, 400)");
            // Undo
            _robot.AssertEnable(UNDO, true);
            _robot.AssertEnable(REDO, false);
            _robot.ClickButton(UNDO);
            _robot.Click(CANVAS, 750, 350);
            _robot.AssertText(INFORMATION_LABEL, "");
            // Redo
            _robot.AssertEnable(UNDO, true);
            _robot.AssertEnable(REDO, true);
            _robot.ClickButton(REDO);
            _robot.Click(CANVAS, 750, 350);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(600, 300, 1000, 400)");
            _robot.AssertEnable(UNDO, true);
            _robot.AssertEnable(REDO, false);
            // Clear
            _robot.ClickButton(CLEAR);
            _robot.AssertEnable(UNDO, false);
            _robot.AssertEnable(REDO, false);
            // Load
            _robot.ClickButton(LOAD);
            _robot.Sleep(2);
            // Check Clear
            _robot.AssertEnable(UNDO, false);
            _robot.AssertEnable(REDO, false);
            _robot.AssertText(INFORMATION_LABEL, "");
            _robot.Click(CANVAS, 700, 250);
            _robot.AssertText(INFORMATION_LABEL, "");
            // Check Shapes Loaded
            _robot.Click(CANVAS, 200, 200);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(100, 100, 300, 300)");
            _robot.Click(CANVAS, 450, 250);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Rectangle(400, 200, 500, 300)");
            _robot.Click(CANVAS, 750, 350);
            _robot.AssertText(INFORMATION_LABEL, "");
            // Move
            _robot.Click(CANVAS, 200, 200);
            _robot.Draw(CANVAS, 200, 200, 800, 500);
            _robot.Click(CANVAS, 800, 500);
            _robot.AssertText(INFORMATION_LABEL, "Selected ： Ellipse(700, 400, 900, 600)");
        }
    }
}
