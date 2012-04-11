using Progressive.TimeAttackOnline.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TimeAttackOnline.CommonsTest
{


    /// <summary>
    ///ServerModelTest のテスト クラスです。すべての
    ///ServerModelTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class ServerModelTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
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

        #region 追加のテスト属性
        // 
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///GetUrl のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TimeAttackOnline.Commons.dll")]
        public void GetUrlTest()
        {
            ServerModel_Accessor target = new ServerModel_Accessor();
            string command = "add";
            string[] parameters = { "param1", "value1", "param2", "value2", "param3", "value3", };
            string expected = "http://tao-prgrssv.herokuapp.com/add?param1=value1&param2=value2&param3=value3";
            string actual;
            actual = target.GetUrl(command, parameters);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }
    }
}
