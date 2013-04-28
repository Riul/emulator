using Emulator.Common.Config;

namespace Sniffer.Config
{
    public class SnifferConfig : ConfigFile
    {
        public const string FILE_PATH = "config.txt";

        public int LoginPort { get; set; }
        public int GamePort { get; set; }
        public string DofusIP { get; set; }
        public int DofusPort { get; set; }

        private SnifferConfig() : base(FILE_PATH)
        {
            LoginPort = int.Parse(GetValue("login_port", "443"));
            GamePort = int.Parse(GetValue("game_port", "444"));
            DofusIP = GetValue("dofus_ip", "213.248.126.39");
            DofusPort = int.Parse(GetValue("dofus_port", "5555"));
        }

        private static SnifferConfig _instance;
        public static SnifferConfig Instance
        {
            get { return _instance ?? (_instance = new SnifferConfig()); }
        }
    }
}
