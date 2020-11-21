using JsonToGraph.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonToGraph.Library.Test
{
    [TestClass]
    public class JsonToGraphParser_Test
    {
        private readonly string _realData = "{\"results\":[{\"gender\":\"female\",\"name\":{\"title\":\"Ms\",\"first\":\"Gül\",\"last\":\"Ayverdi\"},\"location\":{\"street\":{\"number\":3681,\"name\":\"DoktorlarCd\"},\"city\":\"Şanlıurfa\",\"state\":\"Kocaeli\",\"country\":\"Turkey\",\"postcode\":18804,\"coordinates\":{\"latitude\":\"73.6307\",\"longitude\":\"105.1151\"},\"timezone\":{\"offset\":\"+5:00\",\"description\":\"Ekaterinburg,Islamabad,Karachi,Tashkent\"}},\"email\":\"gul.ayverdi@example.com\",\"login\":{\"uuid\":\"72db52c8-1cec-45df-80e5-2c4b13c874f9\",\"username\":\"greencat812\",\"password\":\"thumper\",\"salt\":\"U6XtZ8Yb\",\"md5\":\"5fb9c3bcad2e4df688a121bb632d96fd\",\"sha1\":\"6eb71621051c6c4d3e6071fb6f1bb5cbc9fb46b4\",\"sha256\":\"150c98d53a63f3d6800ba406132748f4cabbf3389fd8aef0be0ddcad5678a10d\"},\"dob\":{\"date\":\"1959-12-20T10:58:08.133Z\",\"age\":61},\"registered\":{\"date\":\"2014-08-03T00:39:26.559Z\",\"age\":6},\"phone\":\"(185)-429-5253\",\"cell\":\"(386)-992-9071\",\"id\":{\"name\":\"\",\"value\":null},\"picture\":{\"large\":\"https://randomuser.me/api/portraits/women/11.jpg\",\"medium\":\"https://randomuser.me/api/portraits/med/women/11.jpg\",\"thumbnail\":\"https://randomuser.me/api/portraits/thumb/women/11.jpg\"},\"nat\":\"TR\"}],\"info\":{\"seed\":\"7d088327d06e845f\",\"results\":1,\"page\":1,\"version\":\"1.3\"}}";

        private readonly string _emptyData = "{}";
        private readonly string _arrayData = "[{\"name\":\"roman\"}, {\"name\":\"avenger\"}]";

        [TestMethod]
        public void GetRootNode_EmptyObject_ReturnsNull()
        {
            JsonToGraphParser parser = new JsonToGraphParser();
            GraphNode node = parser.GetRootNode(_emptyData);
            Assert.AreEqual(null, node);
        }
    }
}
