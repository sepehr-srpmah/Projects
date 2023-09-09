using System;

namespace Generics
{
    class List<T> where T : Product
    {
        public void Add(T obj) { }
        public T this[int index] { get { throw new NotImplementedException(); } }
    }
}