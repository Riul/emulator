﻿#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 17:46
// */
#endregion

using System.Net.Sockets;
using Emulator.Common.Network;
using Emulator.Common.Sql.Models;
using Emulator.Login.Managers;

namespace Emulator.Login.Network
{
    public class AuthClient : Client
    {
        public AuthClient(TcpClient client) : base(client)
        {
            Authentification = new AuthentificationManager(this);
        }

        public AuthentificationManager Authentification { get; private set; }
        public AccountModel Account { get; set; }
        public AuthClientStateEnum State { get; set; }
    }

    public enum AuthClientStateEnum
    {
        HANDSHAKE,
        IN_QUEUE,
        SERVER_LIST
    }
}