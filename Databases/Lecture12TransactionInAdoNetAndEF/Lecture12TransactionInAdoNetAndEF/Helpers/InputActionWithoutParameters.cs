namespace Lecture12TransactionInAdoNetAndEF
{
    using System;
    using System.Collections.Generic;

    public class InputActionWithoutParameters: InputAction
    {
        public InputActionWithoutParameters() 
            : base(null, false)
        {
            this.FunctionToExecutre = null;
        }

        public InputActionWithoutParameters(HashSet<ConsoleKey> keys, bool isFinalAction, Action functionToExecutre) 
            : base(keys, isFinalAction)
        {
            this.FunctionToExecutre = functionToExecutre;
        }

        public Action FunctionToExecutre { get; set; }
        
        public void ExecuteFunction()
        {
            FunctionToExecutre.Invoke();
        }
    }
}
