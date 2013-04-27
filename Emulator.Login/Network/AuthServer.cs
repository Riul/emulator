#region License
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 26/04/2013 at 17:33
#endregion

using System.Collections.Generic;
using System.Net.Sockets;
using Emulator.Common.Network;

namespace Emulator.Login.Network
{
    public class AuthServer : Server
    {
        public List<AuthClient> Clients { get; private set; }

        public AuthServer() : base(Program.Config.LoginPort)
        {
            Clients = new List<AuthClient>();
        }

        protected override void OnClientConnected(TcpClient client)
        {
            base.OnClientConnected(client);
            AuthClient auth = new AuthClient(client);
            auth.ClientDisconnected += OnClientDisconnected;
            Clients.Add(auth);
        }

        private void OnClientDisconnected(Client client)
        {
            foreach (var auth in Clients)
            {
                if (auth == client)
                {
                    Clients.Remove(auth);
                    return;
                }
            }
        }
    }
}
