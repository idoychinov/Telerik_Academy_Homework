namespace Task12Stack
{
    using System;

    public class Stack<T>
    {
        private T[] stack;
        private int currentIndex;

        public Stack()
        {
            this.stack = new T[1];
            this.currentIndex = 0;
        }

        public Stack(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException("Stack size must be greater than 0");
            }

            this.stack = new T[size];
        }
        
        public int Count 
        {
            get 
            {
                return this.currentIndex;
            }
        }

        public void Push(T value)
        {
            this.stack[this.currentIndex] = value;
            this.currentIndex++;
            if (this.currentIndex >= this.stack.Length)
            {
                T[] newStack = new T[this.stack.Length * 2];
                for (int i = 0; i < this.stack.Length; i++)
                {
                    newStack[i] = this.stack[i];
                }

                this.stack = newStack;
            }
        }

        public T Peek()
        {
            this.CheckIfStackEmpty();
            return this.stack[this.currentIndex - 1]; 
        }

        public T Pop()
        {
            this.CheckIfStackEmpty();
            this.currentIndex--;
            return this.stack[this.currentIndex];
        }

        private void CheckIfStackEmpty()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }
    }
}
