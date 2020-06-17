using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeTool.HelperClass {
    
    public class UniqueList<T> : IList<T> {
        private List<T> _innerList;

        public int Count => _innerList.Count;

        public bool IsReadOnly => false;

        public T this[int index] { get => throw new NotImplementedException(); set => _innerList.ElementAt(index); }

        public int IndexOf(T item) {
            return _innerList.IndexOf(item);
        }

        public void Insert(int index, T item) {
            _innerList.Insert(index, item);
        }

        public void RemoveAt(int index) {
            _innerList.RemoveAt(index);
        }

        public void Add(T item) {
            if (!Contains(item)) {
                _innerList.Add(item);
            }
            throw new Exception("The item is already in the list");    
            
        }

        public void Clear() {
            _innerList.Clear();
        }

        public bool Contains(T item) {
            return _innerList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            _innerList.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item) {
            return _innerList.Remove(item);
        }

        public IEnumerator<T> GetEnumerator() {
            return _innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _innerList.GetEnumerator();
        }
 
    }
}
