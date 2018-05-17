using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Kaspersky.Second.Tests
{
    [TestFixture]
    class CoupleBuilderTests
    {
        [Test]
        public void CoupleBuilder_OrdinaryCase() {
            CoupleBuilder cb = new CoupleBuilder(1, 1, 2, 1, 1, 0, 1);
            var ret = cb.BuildWithSum(2);
            Assert.AreEqual(3, ret.Count);
            Assert.AreEqual(new Tuple<int, int>(0, 2), ret[0]);
            Assert.AreEqual(new Tuple<int, int>(1, 1), ret[1]);
            Assert.AreEqual(new Tuple<int, int>(1, 1), ret[2]);
        }
        [Test]
        public void CoupleBuilder_TooBigNumbers()
        {
            CoupleBuilder cb = new CoupleBuilder(1, 1, 2, 1, 1, 0, 1,3,7,4,5);
            var ret = cb.BuildWithSum(2);
            Assert.AreEqual(3, ret.Count);
            Assert.AreEqual(new Tuple<int, int>(0, 2), ret[0]);
            Assert.AreEqual(new Tuple<int, int>(1, 1), ret[1]);
            Assert.AreEqual(new Tuple<int, int>(1, 1), ret[2]);
        }
        [Test]
        public void CoupleBuilder_NoCouples()
        {
            CoupleBuilder cb = new CoupleBuilder(2,4,6,8,2,0,4,2);
            var ret = cb.BuildWithSum(5);
            Assert.AreEqual(0, ret.Count);
        }
        [Test]
        public void CoupleBuilder_SameCouples()
        {
            CoupleBuilder cb = new CoupleBuilder(5,2,2,5,5,2,2,5);
            var ret = cb.BuildWithSum(7);
            Assert.AreEqual(4, ret.Count);
            Assert.AreEqual(new Tuple<int, int>(2, 5), ret[0]);
            Assert.AreEqual(new Tuple<int, int>(2, 5), ret[1]);
            Assert.AreEqual(new Tuple<int, int>(2, 5), ret[2]);
            Assert.AreEqual(new Tuple<int, int>(2, 5), ret[3]);
        }
    }
}
