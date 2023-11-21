using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;

namespace GameLogsTests
{
    public class Tests
    {
        #region private attributes
        string _user = "Logan";
        string _password = "Pa$$W0rd";
        string _keyword = "Tetris";
        //Users _User;
        //Keywords _Keyword;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
           // _User = new Users(_user, _password);
            //_Keyword = new KeyWords(_keyword);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void AllProperties_AfterInstantiation_GetCorrectValues()
        {
            //given

            //when

            //then
            //Assert.AreEqual(_user, _user.User);
            //Assert.AreEqual(_password, _user.User);
            //Assert.AreEqual(_keyword, _keyword.SearchGame);
        }
    }
}