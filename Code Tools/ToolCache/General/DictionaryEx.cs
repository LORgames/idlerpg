using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.General {
    public class DictionaryEx<TKey, TValue> : IDictionary<TKey, TValue> {
        private Dictionary<TKey, TValue> RealDictionary;

        public event EventHandler ItemAdded;
        public event EventHandler ItemRemoved;
        public event EventHandler ItemsChanged;

        public DictionaryEx() {
            RealDictionary = new Dictionary<TKey, TValue>();
        }

        private void OnItemAdded(object o, EventArgs e) {
            if (ItemAdded != null) {
                ItemAdded(o, e);
            }

            OnItemsChanged(o, e);
        }

        private void OnItemRemoved(object o, EventArgs e) {
            if (ItemRemoved != null) {
                ItemRemoved(o, e);
            }

            OnItemsChanged(o, e);
        }

        private void OnItemsChanged(object o, EventArgs e) {
            if (ItemsChanged != null) {
                ItemsChanged(o, e);
            }
        }

        public void Add(TKey key, TValue value) {
            RealDictionary.Add(key, value);

            OnItemAdded(key, new EventArgs());
        }

        public bool Remove(TKey key) {
            OnItemRemoved(key, new EventArgs());

            bool retVal = RealDictionary.Remove(key);

            return retVal;
        }

        /////////////////// NORMAL DICTIONARY CODE
        #region NORMAL DICTIONARY CODE

        public bool ContainsKey(TKey key) {
            return RealDictionary.ContainsKey(key);
        }

        public ICollection<TKey> Keys {
            get { return RealDictionary.Keys; }
        }

        public bool TryGetValue(TKey key, out TValue value) {
            return RealDictionary.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values {
            get {
                return RealDictionary.Values;
            }
        }

        public TValue this[TKey key] {
            get {
                return RealDictionary[key];
            }
            set {
                RealDictionary[key] = value;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item) {
            RealDictionary.Add(item.Key, item.Value);
        }

        public void Clear() {
            RealDictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) {
            return RealDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
            
        }

        public int Count {
            get { return RealDictionary.Count; }
        }

        public bool IsReadOnly {
            get { return false; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) {
            return RealDictionary.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            return RealDictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return RealDictionary.GetEnumerator();
        }
        #endregion
    }
}
