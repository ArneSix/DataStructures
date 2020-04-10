using System.Collections;
using System.Collections.Generic;

namespace DataStructures.structures
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        // fields
        private T[] collection;
        private int _size;
        private int _length;
        
        // properties
        public int Length
        {
            get => _length;
            private set => _length = value;
        }

        public int Size
        {
            get => _size;
            private set => _size = value;
        }

        // Constructors
        public DynamicArray()
        {
            collection = new T[16];
            Size = 16;
            Length = 0;
        }

        public DynamicArray(int arraySize)
        {
            collection = new T[arraySize];
            Size = arraySize;
            Length = 0;
        }

        // Methods
        public void Add(T value)
        {
            if (Size == Length)
            {
                var newDynamicArraySize = Size * 2;
                T[] collectionCopy = collection;
                T[] newCollection = new T[newDynamicArraySize];

                for (var i = 0; i < Size; i++)
                {
                    newCollection[i] = collectionCopy[i];
                }

                collection = newCollection;
                Size = newDynamicArraySize;
            }
            
            collection[Length] = value;
            Length += 1;
        }

        public void Remove(int index)
        {
            // remove item from collection
        }

        // Iteration handlers
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Length; i++)
            {
                yield return collection[i];
            }
        }
    }
}