using Microsoft.VisualStudio.TestTools.UnitTesting;
using PudelkoLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace PudelkoUnitTests
{

    [TestClass]
    public static class InitializeCulture
    {
        [AssemblyInitialize]
        public static void SetEnglishCultureOnAllUnitTest(TestContext context)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }
    }

    // ========================================

    [TestClass]
    public class UnitTestsPudelkoConstructors
    {
        private static double defaultSize = 0.1; // w metrach
        private static double accuracy = 0.001; //dok�adno�� 3 miejsca po przecinku

        private void AssertPudelko(Pudelko p, double expectedA, double expectedB, double expectedC)
        {
            Assert.AreEqual(expectedA, p.A, delta: accuracy);
            Assert.AreEqual(expectedB, p.B, delta: accuracy);
            Assert.AreEqual(expectedC, p.C, delta: accuracy);
        }

        #region Constructor tests ================================

        [TestMethod, TestCategory("Constructors")]
        public void Constructor_Default()
        {
            Pudelko p = new Pudelko();

            Assert.AreEqual(defaultSize, p.A, delta: accuracy);
            Assert.AreEqual(defaultSize, p.B, delta: accuracy);
            Assert.AreEqual(defaultSize, p.C, delta: accuracy);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1.0, 2.543, 3.1,
                 1.0, 2.543, 3.1)]
        [DataRow(1.0001, 2.54387, 3.1005,
                 1.0, 2.543, 3.1)] // dla metr�w licz� si� 3 miejsca po przecinku
        public void Constructor_3params_DefaultMeters(double a, double b, double c,
                                                      double expectedA, double expectedB, double expectedC)
        {
            Pudelko p = new Pudelko(a, b, c);

            AssertPudelko(p, expectedA, expectedB, expectedC);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1.0, 2.543, 3.1,
                 1.0, 2.543, 3.1)]
        [DataRow(1.0001, 2.54387, 3.1005,
                 1.0, 2.543, 3.1)] // dla metr�w licz� si� 3 miejsca po przecinku
        public void Constructor_3params_InMeters(double a, double b, double c,
                                                      double expectedA, double expectedB, double expectedC)
        {
            Pudelko p = new Pudelko(a, b, c, jednostka: UnitOfMeasure.meter);

            AssertPudelko(p, expectedA, expectedB, expectedC);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(100.0, 25.5, 3.1,
                 1.0, 0.255, 0.031)]
        [DataRow(100.0, 25.58, 3.13,
                 1.0, 0.255, 0.031)] // dla centymert�w liczy si� tylko 1 miejsce po przecinku
        public void Constructor_3params_InCentimeters(double a, double b, double c,
                                                      double expectedA, double expectedB, double expectedC)
        {
            Pudelko p = new Pudelko(a: a, b: b, c: c, jednostka: UnitOfMeasure.centimeter);

            AssertPudelko(p, expectedA, expectedB, expectedC);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(100, 255, 3,
                 0.1, 0.255, 0.003)]
        [DataRow(100.0, 25.58, 3.13,
                 0.1, 0.025, 0.003)] // dla milimetr�w nie licz� si� miejsca po przecinku
        public void Constructor_3params_InMilimeters(double a, double b, double c,
                                                     double expectedA, double expectedB, double expectedC)
        {
            Pudelko p = new Pudelko(jednostka: UnitOfMeasure.milimeter, a: a, b: b, c: c);

            AssertPudelko(p, expectedA, expectedB, expectedC);
        }


        // ----

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1.0, 2.5, 1.0, 2.5)]
        [DataRow(1.001, 2.599, 1.001, 2.599)]
        [DataRow(1.0019, 2.5999, 1.001, 2.599)]
        public void Constructor_2params_DefaultMeters(double a, double b, double expectedA, double expectedB)
        {
            Pudelko p = new Pudelko(a, b);

            AssertPudelko(p, expectedA, expectedB, expectedC: 0.1);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1.0, 2.5, 1.0, 2.5)]
        [DataRow(1.001, 2.599, 1.001, 2.599)]
        [DataRow(1.0019, 2.5999, 1.001, 2.599)]
        public void Constructor_2params_InMeters(double a, double b, double expectedA, double expectedB)
        {
            Pudelko p = new Pudelko(a: a, b: b, jednostka: UnitOfMeasure.meter);

            AssertPudelko(p, expectedA, expectedB, expectedC: 0.1);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(11.0, 2.5, 0.11, 0.025)]
        [DataRow(100.1, 2.599, 1.001, 0.025)]
        [DataRow(2.0019, 0.25999, 0.02, 0.002)]
        public void Constructor_2params_InCentimeters(double a, double b, double expectedA, double expectedB)
        {
            Pudelko p = new Pudelko(jednostka: UnitOfMeasure.centimeter, a: a, b: b);

            AssertPudelko(p, expectedA, expectedB, expectedC: 0.1);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(11, 2.0, 0.011, 0.002)]
        [DataRow(100.1, 2599, 0.1, 2.599)]
        [DataRow(200.19, 2.5999, 0.2, 0.002)]
        public void Constructor_2params_InMilimeters(double a, double b, double expectedA, double expectedB)
        {
            Pudelko p = new Pudelko(jednostka: UnitOfMeasure.milimeter, a: a, b: b);

            AssertPudelko(p, expectedA, expectedB, expectedC: 0.1);
        }

        // -------

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(2.5)]
        public void Constructor_1param_DefaultMeters(double a)
        {
            Pudelko p = new Pudelko(a);

            Assert.AreEqual(a, p.A);
            Assert.AreEqual(0.1, p.B);
            Assert.AreEqual(0.1, p.C);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(2.5)]
        public void Constructor_1param_InMeters(double a)
        {
            Pudelko p = new Pudelko(a);

            Assert.AreEqual(a, p.A);
            Assert.AreEqual(0.1, p.B);
            Assert.AreEqual(0.1, p.C);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(11.0, 0.11)]
        [DataRow(100.1, 1.001)]
        [DataRow(2.0019, 0.02)]
        public void Constructor_1param_InCentimeters(double a, double expectedA)
        {
            Pudelko p = new Pudelko(jednostka: UnitOfMeasure.centimeter, a: a);

            AssertPudelko(p, expectedA, expectedB: 0.1, expectedC: 0.1);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(11, 0.011)]
        [DataRow(100.1, 0.1)]
        [DataRow(200.19, 0.2)]
        public void Constructor_1param_InMilimeters(double a, double expectedA)
        {
            Pudelko p = new Pudelko(jednostka: UnitOfMeasure.milimeter, a: a);

            AssertPudelko(p, expectedA, expectedB: 0.1, expectedC: 0.1);
        }

        // ---

        public static IEnumerable<object[]> DataSet1Meters_ArgumentOutOfRangeEx => new List<object[]>
        {
            new object[] {-1.0, 2.5, 3.1},
            new object[] {1.0, -2.5, 3.1},
            new object[] {1.0, 2.5, -3.1},
            new object[] {-1.0, -2.5, 3.1},
            new object[] {-1.0, 2.5, -3.1},
            new object[] {1.0, -2.5, -3.1},
            new object[] {-1.0, -2.5, -3.1},
            new object[] {0, 2.5, 3.1},
            new object[] {1.0, 0, 3.1},
            new object[] {1.0, 2.5, 0},
            new object[] {1.0, 0, 0},
            new object[] {0, 2.5, 0},
            new object[] {0, 0, 3.1},
            new object[] {0, 0, 0},
            new object[] {10.1, 2.5, 3.1},
            new object[] {10, 10.1, 3.1},
            new object[] {10, 10, 10.1},
            new object[] {10.1, 10.1, 3.1},
            new object[] {10.1, 10, 10.1},
            new object[] {10, 10.1, 10.1},
            new object[] {10.1, 10.1, 10.1}
        };

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSet1Meters_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3params_DefaultMeters_ArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p = new Pudelko(a, b, c);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSet1Meters_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3params_InMeters_ArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p = new Pudelko(a, b, c, jednostka: UnitOfMeasure.meter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(1, 1, -1)]
        [DataRow(-1, -1, 1)]
        [DataRow(-1, 1, -1)]
        [DataRow(1, -1, -1)]
        [DataRow(-1, -1, -1)]
        [DataRow(0, 1, 1)]
        [DataRow(1, 0, 1)]
        [DataRow(1, 1, 0)]
        [DataRow(0, 0, 1)]
        [DataRow(0, 1, 0)]
        [DataRow(1, 0, 0)]
        [DataRow(0, 0, 0)]
        [DataRow(0.01, 0.1, 1)]
        [DataRow(0.1, 0.01, 1)]
        [DataRow(0.1, 0.1, 0.01)]
        [DataRow(1001, 1, 1)]
        [DataRow(1, 1001, 1)]
        [DataRow(1, 1, 1001)]
        [DataRow(1001, 1, 1001)]
        [DataRow(1, 1001, 1001)]
        [DataRow(1001, 1001, 1)]
        [DataRow(1001, 1001, 1001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3params_InCentimeters_ArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p = new Pudelko(a, b, c, jednostka: UnitOfMeasure.centimeter);
        }


        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(1, 1, -1)]
        [DataRow(-1, -1, 1)]
        [DataRow(-1, 1, -1)]
        [DataRow(1, -1, -1)]
        [DataRow(-1, -1, -1)]
        [DataRow(0, 1, 1)]
        [DataRow(1, 0, 1)]
        [DataRow(1, 1, 0)]
        [DataRow(0, 0, 1)]
        [DataRow(0, 1, 0)]
        [DataRow(1, 0, 0)]
        [DataRow(0, 0, 0)]
        [DataRow(0.1, 1, 1)]
        [DataRow(1, 0.1, 1)]
        [DataRow(1, 1, 0.1)]
        [DataRow(10001, 1, 1)]
        [DataRow(1, 10001, 1)]
        [DataRow(1, 1, 10001)]
        [DataRow(10001, 10001, 1)]
        [DataRow(10001, 1, 10001)]
        [DataRow(1, 10001, 10001)]
        [DataRow(10001, 10001, 10001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_3params_InMiliimeters_ArgumentOutOfRangeException(double a, double b, double c)
        {
            Pudelko p = new Pudelko(a, b, c, jednostka: UnitOfMeasure.milimeter);
        }


        public static IEnumerable<object[]> DataSet2Meters_ArgumentOutOfRangeEx => new List<object[]>
        {
            new object[] {-1.0, 2.5},
            new object[] {1.0, -2.5},
            new object[] {-1.0, -2.5},
            new object[] {0, 2.5},
            new object[] {1.0, 0},
            new object[] {0, 0},
            new object[] {10.1, 10},
            new object[] {10, 10.1},
            new object[] {10.1, 10.1}
        };

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSet2Meters_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2params_DefaultMeters_ArgumentOutOfRangeException(double a, double b)
        {
            Pudelko p = new Pudelko(a, b);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DynamicData(nameof(DataSet2Meters_ArgumentOutOfRangeEx))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2params_InMeters_ArgumentOutOfRangeException(double a, double b)
        {
            Pudelko p = new Pudelko(a, b, jednostka: UnitOfMeasure.meter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1, 1)]
        [DataRow(1, -1)]
        [DataRow(-1, -1)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(0, 0)]
        [DataRow(0.01, 1)]
        [DataRow(1, 0.01)]
        [DataRow(0.01, 0.01)]
        [DataRow(1001, 1)]
        [DataRow(1, 1001)]
        [DataRow(1001, 1001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2params_InCentimeters_ArgumentOutOfRangeException(double a, double b)
        {
            Pudelko p = new Pudelko(a, b, jednostka: UnitOfMeasure.centimeter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1, 1)]
        [DataRow(1, -1)]
        [DataRow(-1, -1)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(0, 0)]
        [DataRow(0.1, 1)]
        [DataRow(1, 0.1)]
        [DataRow(0.1, 0.1)]
        [DataRow(10001, 1)]
        [DataRow(1, 10001)]
        [DataRow(10001, 10001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_2params_InMilimeters_ArgumentOutOfRangeException(double a, double b)
        {
            Pudelko p = new Pudelko(a, b, jednostka: UnitOfMeasure.milimeter);
        }




        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1.0)]
        [DataRow(0)]
        [DataRow(10.1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_DefaultMeters_ArgumentOutOfRangeException(double a)
        {
            Pudelko p = new Pudelko(a);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1.0)]
        [DataRow(0)]
        [DataRow(10.1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_InMeters_ArgumentOutOfRangeException(double a)
        {
            Pudelko p = new Pudelko(a, jednostka: UnitOfMeasure.meter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1.0)]
        [DataRow(0)]
        [DataRow(0.01)]
        [DataRow(1001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_InCentimeters_ArgumentOutOfRangeException(double a)
        {
            Pudelko p = new Pudelko(a, jednostka: UnitOfMeasure.centimeter);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(0.1)]
        [DataRow(10001)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_1param_InMilimeters_ArgumentOutOfRangeException(double a)
        {
            Pudelko p = new Pudelko(a, jednostka: UnitOfMeasure.milimeter);
        }

        #endregion

    }
}