using System;
using System.Collections;
using System.Collections.Generic;

namespace P05BitArray64
{
    //Problem 5. Define a class BitArray64 to hold 64 bit values inside an ulong value. 
    //Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

    public class BitArray64 : IEnumerable<int>
    {
        private ulong array;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > 63)
            {
                throw new IndexOutOfRangeException("Index must be in the range [0..63]");
            }
        }

        public BitArray64():
            this(0ul)
        {
        }

        public BitArray64(ulong bitArray)
        {
            this.array = bitArray;
        }

        public int this[int index]
        {
            get
            {
                CheckIndex(index);
                ulong mask = 1ul;
                ulong shiftedWithIndex = this.array >> index;
                int result = (int)(shiftedWithIndex & mask);
                return result;
            }
            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentException("Bit can be set only to zero or one");
                }
                CheckIndex(index);
                ulong mask = 1ul;
                ulong shiftedMask = (mask << index);
                this.array = (~shiftedMask) & this.array;
                if (value == 1)
                {
                    this.array = shiftedMask | this.array;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is BitArray64)
            {
                BitArray64 param = obj as BitArray64;
                return this.Equals(param);
            }
            else
            {
                throw new ArgumentException("Argument is invalid type");
            }
        }

        public bool Equals(BitArray64 param)
        {
            if (this.array == param.array)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(BitArray64 operator1, BitArray64 operator2)
        {
            return operator1.Equals(operator2);
        }

        public static bool operator !=(BitArray64 operator1, BitArray64 operator2)
        {
            return !operator1.Equals(operator2);
        }

        public override int GetHashCode()
        {
            return array.GetHashCode();
        }

    }
}
