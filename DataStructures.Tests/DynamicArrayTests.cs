using System;
using DataStructures.structures;
using NUnit.Framework;

namespace DataStructures.Tests
{
    /// <summary>
    /// Fix broken testing code
    /// </summary>
    public class DynamicArrayTests
    {
        [Test]
        public void SizeRescaling()
        {
            DynamicArray<int> dates = new DynamicArray<int>();

            for (var i = 0; i < dates.Size; i++)
            {
                dates.Add(2000 + i);
            }

            Assert.That(dates.Length == 32);
        }

        [Test]
        public void RemoveElement()
        {
            DynamicArray<int> dates = new DynamicArray<int>();

            for (var i = 0; i < dates.Size; i++)
            {
                dates.Add(2000 + i);
            }
            
            dates.Remove(0);

            Assert.That(dates.Size == 15);
        }
    }
}