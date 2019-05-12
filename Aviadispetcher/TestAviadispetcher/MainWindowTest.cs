using Aviadispetcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestAviadispetcher
{
    
    
    /// <summary>
    ///Это класс теста для MainWindowTest, в котором должны
    ///находиться все модульные тесты MainWindowTest
    ///</summary>
    [TestClass()]
    public class MainWindowTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Тест для SelectXY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Aviadispetcher.exe")]
        public void SelectXYTest()
        {
            MainWindow_Accessor target = new MainWindow_Accessor();
            MainWindow.logUser = 1;
            target.InfoFlightForm_Loaded(target, null);
            DateTime timeFlight = Convert.ToDateTime("10:00");
            List<Flight> expected = new List<Flight>(10);
            expected.Add(new Flight("КВ-834", "Відень", "13:40", "45"));
            List<Flight> actual;
            target.selectedCityList.Add(new Flight("КВ-834", "Відень", "13:40", "45"));
            target.selectedCityList.Add(new Flight("КМ-202", "Відень", "7:35", "32"));
            actual = target.SelectXY(timeFlight);
            Assert.AreEqual(expected[0].ToString(), actual[0].ToString());
        }

        /// <summary>
        ///Тест для SelectX
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Aviadispetcher.exe")]
        public void SelectXTest()
        {
            MainWindow_Accessor target = new MainWindow_Accessor(); 
            MainWindow.logUser = 1;
            target.InfoFlightForm_Loaded(target, null);
            target.LoadDataMenuItem_Click(target, null);
            string selCity = "Відень";
            List<Flight> expected = new List<Flight>(10);
            expected.Add(new Flight("КВ-834", "Відень", "13:40", "45"));
            
            List<Flight> actual;
            actual = target.SelectX(selCity);
            Assert.AreEqual(expected[0].ToString(), actual[0].ToString());
        }

        /// <summary>
        ///Тест для FillCityList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Aviadispetcher.exe")]
        public void FillCityListTest()
        {
            MainWindow_Accessor target = new MainWindow_Accessor();
            target.InfoFlightForm_Loaded(target, null);
            target.FillCityList();
            string[] expected = { "Київ", "Лондон", 
            "Париж", "Відень", "Москва", "Берлін", "Мюнхен", "Мадрид" };
            string[] actual = new string[target.cityList.Items.Count];
            for (int i = 0; i < target.cityList.Items.Count; i++)
            {
                actual[i] = target.cityList.Items[i].ToString();
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
