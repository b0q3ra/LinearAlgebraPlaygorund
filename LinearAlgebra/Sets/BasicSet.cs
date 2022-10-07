using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Sets
{
    public class BasicSet<T>
    {
        private IList<T> _thisSet = new List<T>();

        public int Count { get { return _thisSet.Count; } }

        public bool isReadOnly { get { return false; } }

        public T this[int i] { get { return _thisSet[i]; } }

        public bool Add(T item)
        {
            T? element = _thisSet.Where(x =>  x != null && x.Equals(item)).FirstOrDefault();
            
            if (element == null)
            {
                _thisSet.Add(item);
                return true;
            }

            return false;
            
        }

        public void Clear(T item)
        {
            _thisSet.Clear();
        }

        public bool Contains(T item)
        {
            return _thisSet.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _thisSet.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _thisSet.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _thisSet.GetEnumerator();
        }

        public void UnionWith(ISet<T> otherSet)
        {
            foreach(var item in otherSet)
            {
                Add(item);
            }
        }

        public void IntersectWith(ISet<T> otherSet)
        {
            var itemsToRemove = new List<T>();

            for (int i = 0; i < Count; i++)
            {
                T item = this[i];

                if (!otherSet.Contains(item))
                    itemsToRemove.Add(item);
            }

            foreach (var itemToRemove in itemsToRemove)
                Remove(itemToRemove);
        }

        public override string ToString()
        {
            var setStringBuilder = new StringBuilder();
            setStringBuilder.Append("{");

            foreach (var item in _thisSet)
                setStringBuilder.Append(
                    string.Format(" {0},", item));

            return string.Format("{0} }}",
                setStringBuilder.ToString().TrimEnd(','));
        }

    }
}
