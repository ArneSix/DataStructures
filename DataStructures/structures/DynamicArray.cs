using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.structures
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] _collection;
        private int _size;
        private int _length;
        
        /// <summary>
        /// Get the amount of non-null values in the collection
        /// </summary>
        public int Length
        {
            get => _length;
            private set => _length = value;
        }

        /// <summary>
        /// Get the allocated collection size
        /// </summary>
        public int Size
        {
            get => _size;
            private set => _size = value;
        }

        private T[] Collection
        {
            get => _collection;
            set => _collection = value;
        }

        /// <summary>
        /// Generates a default collection class
        /// </summary>
        public DynamicArray()
        {
            Collection = new T[16];
            Size = 16;
            Length = 0;
        }

        /// <summary>
        /// Generates a collection class with custom size
        /// </summary>
        /// <param name="arraySize">size of the collection</param>
        public DynamicArray(int arraySize)
        {
            Collection = new T[arraySize];
            Size = arraySize;
            Length = 0;
        }

        /// <summary>
        /// Add an item to the end of the collection
        /// </summary>
        /// <param name="value">Item to add to the collection</param>
        public void Add(T value)
        {
            if (Size == Length)
            {
                var newDynamicArraySize = Size * 2;
                T[] collectionCopy = Collection;
                T[] newCollection = new T[newDynamicArraySize];

                for (var i = 0; i < Size; i++)
                {
                    newCollection[i] = collectionCopy[i];
                }

                Collection = newCollection;
                Size = newDynamicArraySize;
            }
            
            Collection[Length] = value;
            Length += 1;
        }
        
        /// <summary>
        /// Remove an item from the collection by giving the index
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Remove(int index)
        {
            if (index < 0 || index > Size) throw new IndexOutOfRangeException();            
            
            T[] collectionCopy = Collection;
            T[] newCollection = new T[Length - 1];
            
            for (int i = 0, j = 0; i < Length - 1 && j < Length - 1; i++, j++)
            {

                if (i == index)
                {
                    j += 1;
                }

                newCollection[i] = collectionCopy[j];
            }

            Length -= 1;
            Collection = newCollection;
        }

        /// <summary>
        /// Remove the item at the last index
        /// </summary>
        public void RemoveEnd()
        {
            Collection[Length - 1] = default(T);
            Length -= 1;
        }
        
        /// <summary>
        /// Insert an item into the collection by providing the index and value to add
        /// </summary>
        /// <param name="index">position to insert into</param>
        /// <param name="value">value to insert</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Insert(int index, T value)
        {
            if (index < 0 || index > Size) throw new IndexOutOfRangeException();

            T[] collectionCopy = Collection;
            T[] newCollection = new T[Length + 1];

            for (int i = 0, j = 0; i < Length + 1 && j < Length + 1; i++, j++)
            {
                if (i == index)
                {
                    j -= 1;
                    newCollection[i] = value;
                }
                else
                {
                    newCollection[i] = collectionCopy[j];
                }
            }
            
            Length += 1;
            Collection = newCollection;
        }

        /// <summary>
        /// Deletes the element at the provided location index and returns the deleted element
        /// </summary>
        /// <param name="index">position of the value to delete</param>
        public T Pop(int index)
        {
            if (index < 0 || index > Length) throw new IndexOutOfRangeException();

            T[] collectionCopy = Collection;
            T[] newCollection = new T[Size - 1];
            T toPopElement = default(T);

            for (int i = 0, j = 0; i < Length - 1 && j < Length - 1; i++, j++)
            {
                if (index == i)
                {
                    toPopElement = collectionCopy[i];
                    j += 1;
                }
                
                newCollection[i] = collectionCopy[j];
            }

            return toPopElement;
        }
        
        /// <summary>
        /// Deletes the element at end of the collection and returns the deleted element
        /// </summary>
        public T PopEnd()
        {
            T toPopItem = Collection[Length - 1];
            Collection[Length - 1] = default(T);
            Length -= 1;

            return toPopItem;
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
                yield return Collection[i];
            }
        }
    }
}