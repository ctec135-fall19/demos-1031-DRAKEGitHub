using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// add libraries/dictionaries
using MyMath1;
using NUnit.Framework;

namespace MyMath1.UnitTests
{
    [TestFixture]
    public class MyMath1Tests
    {
        [Test]
        public void Add_SumWithinByteRange_ReturnCorrectSum()
        {
            Assert.AreEqual(200, MyMath.MyMath1.Add(101, 99));
        }
    }
}
