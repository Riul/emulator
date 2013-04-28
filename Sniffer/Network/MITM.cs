using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Emulator.Common;
using Emulator.Common.Network;
using Sniffer.Config;

namespace Sniffer.Network
{
    public class MITM
    {
        public Dictionary<string, Tuple<string, int>> Tickets { get; set; }
        public Server LoginServer { get; private set; }
        public Server GameServer { get; private set; }

        public MITM()
        {
            LoginServer = new Server(SnifferConfig.Instance.LoginPort);
            GameServer = new Server(SnifferConfig.Instance.GamePort);
            Tickets = new Dictionary<string, Tuple<string, int>>();
        }

        public void Start()
        {
            LoginServer.ClientConnected += LoginServerOnClientConnected;
            GameServer.ClientConnected += GameServerOnClientConnected;
            LoginServer.Start();
            GameServer.Start();
            Logger.Info("MITM servers started.");
        }

        public void Stop()
        {
            LoginServer.ClientConnected -= LoginServerOnClientConnected;
            GameServer.ClientConnected -= GameServerOnClientConnected;
            LoginServer.Stop();
            GameServer.Stop();
            Logger.Info("MITM servers stopped.");
        }

        private void LoginServerOnClientConnected(object sender, TcpClient client)
        {
            Logger.Info("New login client connected !");
            new LoginClient(client);
        }

        private void GameServerOnClientConnected(object sender, TcpClient client)
        {
            Logger.Info("New game client connected !");
            new GameClient(client);
        }
    }
}
