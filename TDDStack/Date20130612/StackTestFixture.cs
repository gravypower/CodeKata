// -----------------------------------------------------------------------
// <copyright file="StackTestFixture.cs" company="bah">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace TDDStack.Date20130612
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NUnit.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class StackTestFixture
    {
        [Test]
        public void Creat_NewStach_ShouldBeEmpty()
        {
            // Arrange
            var stack = new Stack(0);

            // Act
            
            // Assert
            Assert.AreEqual(0, stack.Size());
        }

        [Test]
        public void Push_ToStach_SizeShouldBeOne()
        {
            // Arrange
            var stack = new Stack(1);

            // Act
            stack.Push(0);

            // Assert
            Assert.AreEqual(1, stack.Size());
        }

        [Test]
        public void PushAndPop_ToAndFromStack_SizeShoudBe0()
        {
            // Arrange
            var stack = new Stack(1);

            // Act
            stack.Push(0);
            stack.Pop();

            // Assert
            Assert.AreEqual(0, stack.Size());
        }

        [Test]
        [ExpectedException(typeof(StackUnderflow))]
        public void Pop_FromEmptyStack_ThrowsStackUnderflowException()
        {
            // Arrange
            var stack = new Stack(0);

            // Act
            stack.Pop();

            // Assert
        }

        [Test]
        [ExpectedException(typeof(StackOverflow))]
        public void Push_ToFullStact_ThrowsStackOverflowException()
        {
            // Arrange
            var stack = new Stack(2);

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Assert
        }

        [Test]
        public void PushOneAndPop_ToAndFromStach_Returns1()
        {
            // Arrange
            var stack = new Stack(1);

            // Act
            stack.Push(1);

            // Assert
            Assert.AreEqual(1, stack.Pop());
        }

        [Test]
        public void PushAndPop_ToAndFromStach_ArePopedInReverseOrder()
        {
            // Arrange
            var stack = new Stack(2);

            // Act
            stack.Push(1);
            stack.Push(2);

            // Assert
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }
    }
}
