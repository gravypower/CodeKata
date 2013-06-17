// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stack.cs" company="dsa">
//   ds
// </copyright>
// <summary>
//   Defines the Stack type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TDDStack.Date20130612
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The stack.
    /// </summary>
    public class Stack
    {
        /// <summary>
        /// The capacity.
        /// </summary>
        private readonly int capacity;

        /// <summary>
        /// The element.
        /// </summary>
        private readonly int[] elements;

        /// <summary>
        /// The size.
        /// </summary>
        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack"/> class.
        /// </summary>
        /// <param name="capacity">
        /// The capacity.
        /// </param>
        public Stack(int capacity)
        {
            this.capacity = capacity;
            this.elements = new int[capacity];
        }

        /// <summary>
        /// The size.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Size()
        {
            return this.size;
        }

        /// <summary>
        /// The push.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        /// <exception cref="StackOverflow">
        /// Throws this excption if stack is full
        /// </exception>
        public void Push(int o)
        {
            if (this.size == this.capacity)
            {
                throw new StackOverflow();
            }

            this.elements[this.size++] = o;
        }

        /// <summary>
        /// The pop.
        /// </summary>
        /// <exception cref="StackUnderflow">
        /// Throws this excption if stack is empty
        /// </exception>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Pop()
        {
            if (this.size == 0)
            {
                throw new StackUnderflow();
            }

            return this.elements[--this.size];
        }
    }
}
