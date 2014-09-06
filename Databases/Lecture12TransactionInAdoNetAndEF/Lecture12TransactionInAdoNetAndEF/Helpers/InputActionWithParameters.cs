namespace Lecture12TransactionInAdoNetAndEF
{
    using System;
    using System.Collections.Generic;

    public class InputActionWithParameters<T,R> : InputAction
    {
        public InputActionWithParameters() 
            : base(null, false)
        {
            this.FunctionToExecutre = null;
        }

        public InputActionWithParameters(HashSet<ConsoleKey> keys, bool isFinalAction, T param, Func<T,R> functionToExecutre) 
            : base(keys, isFinalAction)
        {
            this.Param = param;
            this.FunctionToExecutre = functionToExecutre;
        }

        public Func<T,R> FunctionToExecutre { get; set; }

        public T Param { get; set; }


        public R ExecuteFunction()
        {
            return FunctionToExecutre.Invoke(Param);
        }
    }
}
