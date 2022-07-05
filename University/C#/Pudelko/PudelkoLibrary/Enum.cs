using System;
using System.Collections;
using System.Collections.Generic;


namespace PudelkoLib
{
    class Enum : IEnumerator<double>
    {
        private readonly Pudelko pudelko;
        private int i = 0;

        public Enum(Pudelko pudelko)
        {
            this.pudelko = pudelko;
        }

        public double Current => pudelko[i++];

        object IEnumerator.Current => pudelko[i++];

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return i <= 1;
        }

        public void Reset()
        {
            i = 0;
        }
    }
}
