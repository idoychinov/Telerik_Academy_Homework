namespace Lecture12TransactionInAdoNetAndEF
{
    using System;
    using System.Collections.Generic;

    public abstract class InputAction
    {
        public InputAction(HashSet<ConsoleKey> keys, bool IsFinalAction)
        {
            this.Keys = keys;
            this.IsFinalAction = IsFinalAction;            
        }

        public HashSet<ConsoleKey> Keys {get; set;}

        public bool IsFinalAction {get; set;}

    }
}
