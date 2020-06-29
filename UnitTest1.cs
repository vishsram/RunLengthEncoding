using System;
using NUnit.Framework;

namespace RunLengthEncoding
{
    public class Tests
    {
        private Program converter;

        [SetUp]
        public void Setup()
        {
            converter = new Program();
        }

        [Test]
        public void Test_RLE()
        {
            Assert.AreEqual("2A3B4C5D", converter.ConvertRLE("AABBBCCCCDDDDD"));
        }

        [Test]
        public void Test_RLE2()
        {
            Assert.AreEqual("1Z1Y1X", converter.ConvertRLE("ZYX"));
        }

        [Test]
        public void Test_RLE3()
        {
            Assert.AreEqual("2f1u6n", converter.ConvertRLE("ffunnnnnn"));
        }

        [Test]
        public void Test_RLE_Empty()
        {
            Assert.AreEqual("", converter.ConvertRLE(""));
        }

        [Test]
        public void Test_RLE_SpecialChars()
        {
            Assert.AreEqual("1:1,1(1)", converter.ConvertRLE(":,()"));
        }

        [Test]
        public void Test_RLE_Reverse()
        {
            Assert.AreEqual("AABBBCCCCDDDDD", converter.RevertRLE("2A3B4C5D"));
        }

        [Test]
        public void Test_RLE_Reverse2()
        {
            Assert.AreEqual("wzr", converter.RevertRLE("1w1z1r"));
        }

        [Test]
        public void Test_RLE_ReverseEmpty()
        {
            Assert.AreEqual("", converter.RevertRLE(""));
        }

        [Test]
        public void Test_RLE_ReverseOddLength()
        {
            Assert.Throws<ArgumentException>(() => converter.RevertRLE("2A3B4C5"));
        }

        [Test]
        public void Test_RLE_ReverseWrongInput()
        {
            Assert.Throws<ArgumentException>(() => converter.RevertRLE("ArA3B4C5"));
        }

    }
}