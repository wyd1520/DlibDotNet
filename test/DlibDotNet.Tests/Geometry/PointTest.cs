﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DlibDotNet.Tests.Geometry
{

    [TestClass]
    public class PointTest : TestBase
    {

        [TestMethod]
        public void Create1()
        {
            var point = new Point();
            this.DisposeAndCheckDisposedState(point);
        }

        [TestMethod]
        public void Create2()
        {
            var x = this.NextRandom(0, 100);
            var y = this.NextRandom(0, 100);
            var point = new Point(x, y);
            Assert.AreEqual(point.X, x);
            Assert.AreEqual(point.Y, y);
            Assert.AreEqual(point.Z, 0);
            this.DisposeAndCheckDisposedState(point);
        }

        [TestMethod]
        public void Length()
        {
            var x = this.NextRandom(1, 100);
            var y = this.NextRandom(1, 100);
            var point = new Point(x, y);
            var length = Math.Sqrt(x * x + y * y);
            Assert.AreEqual(point.Length, length);
            this.DisposeAndCheckDisposedState(point);
        }

        [TestMethod]
        public void Rotate()
        {
            const int away = 90;
            var x = 10;
            var y = 20;
            var point = new Point(x, y);
            var move = new Point(-away, 0);
            var p = point + move;

            for (var i = 1; i <= 3; i++)
            {
                var rotated = point.Rotate(p, 90 * i);

                switch (i)
                {
                    case 1:
                        Assert.AreEqual(rotated.X, x, $"Check X and Rotate: {90 * i}");
                        Assert.AreEqual(rotated.Y, y - away, $"Check Y Rotate: {90 * i}");
                        break;
                    case 2:
                        Assert.AreEqual(rotated.X, x + away, $"Check X and Rotate: {90 * i}");
                        Assert.AreEqual(rotated.Y, y, $"Check Y Rotate: {90 * i}");
                        break;
                    case 3:
                        Assert.AreEqual(rotated.X, x, $"Check X and Rotate: {90 * i}");
                        Assert.AreEqual(rotated.Y, y + away, $"Check Y and Rotate: {90 * i}");
                        break;
                }

                this.DisposeAndCheckDisposedState(rotated);
            }

            this.DisposeAndCheckDisposedState(point);
            this.DisposeAndCheckDisposedState(move);
            this.DisposeAndCheckDisposedState(p);
        }

        [TestMethod]
        public void Rotate2()
        {
            const int away = 90;
            var x = 10;
            var y = 20;
            var point = new Point(x, y);
            var move = new Point(-away, 0);
            var p = point + move;

            for (var i = 1; i <= 3; i++)
            {
                var rotated = Point.Rotate(point, p, 90 * i);

                switch (i)
                {
                    case 1:
                        Assert.AreEqual(rotated.X, x, $"Check X and Rotate: {90 * i}");
                        Assert.AreEqual(rotated.Y, y - away, $"Check Y Rotate: {90 * i}");
                        break;
                    case 2:
                        Assert.AreEqual(rotated.X, x + away, $"Check X and Rotate: {90 * i}");
                        Assert.AreEqual(rotated.Y, y, $"Check Y Rotate: {90 * i}");
                        break;
                    case 3:
                        Assert.AreEqual(rotated.X, x, $"Check X and Rotate: {90 * i}");
                        Assert.AreEqual(rotated.Y, y + away, $"Check Y and Rotate: {90 * i}");
                        break;
                }

                this.DisposeAndCheckDisposedState(rotated);
            }

            this.DisposeAndCheckDisposedState(point);
            this.DisposeAndCheckDisposedState(move);
            this.DisposeAndCheckDisposedState(p);
        }

        [TestMethod]
        public void LengthSquared()
        {
            var x = this.NextRandom(1, 100);
            var y = this.NextRandom(1, 100);
            var point = new Point(x, y);
            var lengthSquared = x * x + y * y;
            Assert.AreEqual(point.LengthSquared, lengthSquared);
            this.DisposeAndCheckDisposedState(point);
        }

        [TestMethod]
        public void OperatorAdd()
        {
            var lx = this.NextRandom(0, 100);
            var ly = this.NextRandom(0, 100);
            var rx = this.NextRandom(0, 100);
            var ry = this.NextRandom(0, 100);

            var r = new Point(lx, ly);
            var l = new Point(rx, ry);
            var rl = r + l;

            Assert.AreEqual(rl.X, lx + rx);
            Assert.AreEqual(rl.Y, ly + ry);

            this.DisposeAndCheckDisposedState(rl);
            this.DisposeAndCheckDisposedState(l);
            this.DisposeAndCheckDisposedState(r);
        }

        [TestMethod]
        public void OperatorSub()
        {
            var lx = this.NextRandom(0, 100);
            var ly = this.NextRandom(0, 100);
            var rx = this.NextRandom(0, 100);
            var ry = this.NextRandom(0, 100);

            var r = new Point(lx, ly);
            var l = new Point(rx, ry);
            var rl = r - l;

            Assert.AreEqual(rl.X, lx - rx);
            Assert.AreEqual(rl.Y, ly - ry);

            this.DisposeAndCheckDisposedState(rl);
            this.DisposeAndCheckDisposedState(l);
            this.DisposeAndCheckDisposedState(r);
        }

        [TestMethod]
        public void OperatorMul()
        {
            var lx = this.NextRandom(10, 100);
            var ly = this.NextRandom(10, 100);

            var r = new Point(lx, ly);
            var l = 2;
            var rl = r * l;

            Assert.AreEqual(rl.X, lx * l);
            Assert.AreEqual(rl.Y, ly * l);

            this.DisposeAndCheckDisposedState(rl);
            this.DisposeAndCheckDisposedState(r);
        }

        [TestMethod]
        public void OperatorDiv()
        {
            var lx = this.NextRandom(10, 100);
            var ly = this.NextRandom(10, 100);

            var r = new Point(lx, ly);
            var l = 2;
            var rl = r / l;

            Assert.AreEqual(rl.X, lx / l);
            Assert.AreEqual(rl.Y, ly / l);

            this.DisposeAndCheckDisposedState(rl);
            this.DisposeAndCheckDisposedState(r);
        }

        [TestMethod]
        public void OperatorDivByZero()
        {
            var lx = this.NextRandom(10, 100);
            var ly = this.NextRandom(10, 100);

            Point r = null;

            try
            {
                r = new Point(lx, ly);
                var rl = r / 0;
                Assert.Fail("Should throw DivideByZeroException when Point was divided by 0");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("OK");
            }
            finally
            {
                if (r != null)
                    this.DisposeAndCheckDisposedState(r);
            }
        }

        [TestMethod]
        public void OperatorEqual()
        {
            var x = this.NextRandom(0, 100);
            var y = this.NextRandom(0, 100);

            var r = new Point(x, y);
            var l = new Point(x, y);
            var l1 = new Point(x * 2, y);
            var l2 = new Point(x, y * 2);

            Assert.IsTrue(r == l);
            Assert.IsTrue(r != l1);
            Assert.IsTrue(r != l2);

            this.DisposeAndCheckDisposedState(l);
            this.DisposeAndCheckDisposedState(r);
            this.DisposeAndCheckDisposedState(l1);
            this.DisposeAndCheckDisposedState(l2);
        }

    }
}
