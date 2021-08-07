using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PWToolKit;
using System.IO;

namespace CoreBackLog.Server
{
    public class ServerConnection
    {
        public string rootPath { get; set; }
        public string logsPath { get; set; }
        public PwVersion PwVersion { get; set; }
        public Gamedbd Gamedbd { get; set; }
        public GProvider GProvider { get; set; }
        public GDeliveryd GDeliveryd { get; set; }

        public ServerConnection()
        {
            JObject jsonNodes = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("./Configurations/ServerConnection.json"));

            this.logsPath = jsonNodes["LOGS_PATH"].ToObject<string>();
            this.PwVersion = (PwVersion)jsonNodes["PW_VERSION"].ToObject<int>();
            this.Gamedbd = new Gamedbd(jsonNodes["GAMEDBD"]["HOST"].ToObject<string>(), jsonNodes["GAMEDBD"]["PORT"].ToObject<int>());
            this.GProvider = new GProvider(jsonNodes["GPROVIDER"]["HOST"].ToObject<string>(), jsonNodes["GPROVIDER"]["PORT"].ToObject<int>());
            this.GDeliveryd = new GDeliveryd(jsonNodes["GDELIVERYD"]["HOST"].ToObject<string>(), jsonNodes["GDELIVERYD"]["PORT"].ToObject<int>());
        }
    }
}
