using System;
using System.Collections;
using System.Collections.Generic;

namespace e_cash
{
    [Serializable]
    public struct IdentityStringPair<T> : IEnumerable<T>
    {
        private readonly T _left;
        private readonly T _right;

        public IdentityStringPair(T left, T right)
        {
            _left = left;
            _right = right;
        }

        public T Left
        {
            get { return _left; }
        }

        public T Right
        {
            get { return _right; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Left;
            yield return Right;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}