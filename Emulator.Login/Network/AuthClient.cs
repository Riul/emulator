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
// Created on 26/04/2013 at 17:46
#endregion

using System.Net.Sockets;
using Emulator.Common.Network;
using Emulator.Common.Sql.Models;
using Emulator.Login.Managers;

namespace Emulator.Login.Network
{
    public class AuthClient : Client
    {
        public AuthentificationManager Authentification { get; private set; }
        public AccountModel Account { get; set; }
        public AuthClientStateEnum State { get; set; }

        public AuthClient(TcpClient client) : base(client)
        {
            Authentification = new AuthentificationManager(this);
        }
    }

    public enum AuthClientStateEnum
    {
        HANDSHAKE,
        IN_QUEUE,
        SERVER_LIST
    }
}
