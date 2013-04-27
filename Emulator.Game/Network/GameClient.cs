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
// Created on 27/04/2013 at 13:31
#endregion

using System.Net.Sockets;
using Emulator.Common.Network;
using Emulator.Common.Sql.Models;
using Emulator.Game.Approach;

namespace Emulator.Game.Network
{
    public class GameClient : Client
    {
        public AccountModel Account { get; set; }
        public ApproachManager Approach { get; private set; }

        public GameClient(TcpClient client) : base(client)
        {
            Approach = new ApproachManager(this);
        }
    }
}
