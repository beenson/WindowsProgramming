using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DrawingModel.Tests
{
    [TestClass]
    public class CommmandManagerTests
    {
        Model model = new Model();
        CommandManager commandManager = new CommandManager();
        PrivateObject privateObject;
        DrawCommand A, B, C;

        //Initialize
        [TestInitialize]
        public void Initialize()
        {
            A = new DrawCommand(model, new Ellipse());
            B = new DrawCommand(model, new Rectangle());
            C = new DrawCommand(model, new Ellipse());
            privateObject = new PrivateObject(commandManager);
        }

        // Undo Exception Test
        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot Undo exception\n")]
        public void UndoExceptionTest()
        {
            commandManager.Undo();
        }

        // Redo Exception Test
        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot Redo exception\n")]
        public void RedoExceptionTest()
        {
            commandManager.Redo();
        }

        // Execute Test
        [TestMethod]
        public void ExecuteTest()
        {
            commandManager.Execute(A);
            Stack<ICommand> undo = (Stack<ICommand>)privateObject.GetField("undo");
            Assert.AreEqual(1, undo.Count);
            commandManager.Execute(A);
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            Assert.AreEqual(2, undo.Count);
            commandManager.Execute(B);
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            Assert.AreEqual(3, undo.Count);
        }

        // Redo Undo Test
        [TestMethod]
        public void RedoUndoTest()
        {
            Assert.IsFalse(commandManager.IsRedoEnabled);
            Assert.IsFalse(commandManager.IsUndoEnabled);
            commandManager.Execute(A);
            Stack<ICommand> undo = (Stack<ICommand>)privateObject.GetField("undo");
            Stack<ICommand> redo = (Stack<ICommand>)privateObject.GetField("redo");
            Assert.AreEqual(1, undo.Count);
            Assert.AreEqual(0, redo.Count);
            Assert.IsFalse(commandManager.IsRedoEnabled);
            Assert.IsTrue(commandManager.IsUndoEnabled);
            commandManager.Execute(A);
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            redo = (Stack<ICommand>)privateObject.GetField("redo");
            Assert.AreEqual(2, undo.Count);
            Assert.AreEqual(0, redo.Count);
            Assert.IsFalse(commandManager.IsRedoEnabled);
            Assert.IsTrue(commandManager.IsUndoEnabled);
            commandManager.Execute(B);
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            redo = (Stack<ICommand>)privateObject.GetField("redo");
            Assert.AreEqual(3, undo.Count);
            Assert.AreEqual(0, redo.Count);
            Assert.IsFalse(commandManager.IsRedoEnabled);
            Assert.IsTrue(commandManager.IsUndoEnabled);
            commandManager.Undo();
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            redo = (Stack<ICommand>)privateObject.GetField("redo");
            Assert.AreEqual(2, undo.Count);
            Assert.AreEqual(1, redo.Count);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            Assert.IsTrue(commandManager.IsUndoEnabled);
            commandManager.Undo();
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            redo = (Stack<ICommand>)privateObject.GetField("redo");
            Assert.AreEqual(1, undo.Count);
            Assert.AreEqual(2, redo.Count);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            Assert.IsTrue(commandManager.IsUndoEnabled);
            commandManager.Undo();
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            redo = (Stack<ICommand>)privateObject.GetField("redo");
            Assert.AreEqual(0, undo.Count);
            Assert.AreEqual(3, redo.Count);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            Assert.IsFalse(commandManager.IsUndoEnabled);
            commandManager.Redo();
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            redo = (Stack<ICommand>)privateObject.GetField("redo");
            Assert.AreEqual(1, undo.Count);
            Assert.AreEqual(2, redo.Count);
            Assert.IsTrue(commandManager.IsRedoEnabled);
            Assert.IsTrue(commandManager.IsUndoEnabled);
            commandManager.Reset();
            undo = (Stack<ICommand>)privateObject.GetField("undo");
            redo = (Stack<ICommand>)privateObject.GetField("redo");
            Assert.AreEqual(0, undo.Count);
            Assert.AreEqual(0, redo.Count);
            Assert.IsFalse(commandManager.IsRedoEnabled);
            Assert.IsFalse(commandManager.IsUndoEnabled);
        }
    }
}
