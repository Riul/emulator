#region License
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
//     Created on 26/04/2013 at 18:47
// */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Emulator.Common;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Protocol.Enums;
using Emulator.Common.Protocol.Net.Messages.Connection;
using Emulator.Common.Protocol.Net.Types.Connection;
using Emulator.Common.Sql.Models;
using Emulator.Common.Sql.Tables;
using Emulator.Login.Network;
using Emulator.Login.Network.Sync;

namespace Emulator.Login.Managers
{
    public class ServersManager
    {
        private readonly AuthClient client;

        public ServersManager(AuthClient client)
        {
            this.client = client;
            client.Dispatcher.Register(this);
        }

        public void SendServerList()
        {
            if (client.State != AuthClientStateEnum.SERVER_LIST)
            {
                Logger.Warning("Trying to send the server list to a client wich is not in the server selection frame.");
                return;
            }
            client.Send(new ServersListMessage(GetServers()));
        }

        [MessageHandler(ServerSelectionMessage.Id)]
        public void HandleServerSelectionMessage(ServerSelectionMessage message)
        {
            if (!SelectServer(message.serverId))
            {
                Logger.Warning("User {0} trying to connect to an unknow server.", client.Account.Username);
                client.Stop();
            }
        }

        public static void UpdateServer(int id)
        {
            ServerModel server = ServersTable.Load(id);
            if (server != null)
            {
                foreach (var client in Program.Server.Clients)
                {
                    if (client.State == AuthClientStateEnum.SERVER_LIST)
                    {
                        GameServerInformations infos = new GameServerInformations
                        {
                            id = (ushort)server.Id,
                            completion = 0,
                            status = (sbyte)server.Status,
                            isSelectable = true,
                            date = 0,
                            charactersCount = (sbyte)client.Account.Characters.Where(a => a.ServerId == server.Id).ToArray().Length
                        };
                        client.Send(new ServerStatusUpdateMessage(infos));
                    }
                }
            }
        }

        public bool SelectServer(int id)
        {
            ServerModel server = ServersTable.Load(id);
            if (server == null || server.Status != ServerStatusEnum.ONLINE)
            {
                return false;
            }

            string ticket = GenerateTicket();

            //sending the ticket to the game server
            SyncClient gameServer = Program.SyncServer.GetServer(id);
            if (gameServer == null)
            {
                return false;
            }
            gameServer.SendTicket(ticket, client.Account.Id);

            //Sending data to the client
            SelectedServerDataMessage dataMessage = new SelectedServerDataMessage
            {
                address = server.Ip,
                port = (ushort)server.Port,
                canCreateNewCharacter = true,
                serverId = (short)server.Id,
                ticket = ticket
            };

            client.Account.LastServer = id;
            client.Send(dataMessage);
            client.Stop();
            return true;
        }

        private GameServerInformations[] GetServers()
        {
            List<GameServerInformations> servers = new List<GameServerInformations>();
            foreach (var server in ServersTable.Load())
            {
                GameServerInformations infos = new GameServerInformations
                {
                    id = (ushort)server.Id,
                    completion = 0,
                    status = (sbyte)server.Status,
                    isSelectable = true,
                    date = 0,
                    charactersCount = (sbyte)client.Account.Characters.Where(a => a.ServerId == server.Id).ToArray().Length
                };
                servers.Add(infos);
            }
            return servers.ToArray();
        }

        private string GenerateTicket()
        {
            string ticket = "";
            Random rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                ticket += (char)rand.Next(30, 81);
            }
            return ticket;
        }
    }
}
