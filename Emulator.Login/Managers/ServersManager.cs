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
// Created on 26/04/2013 at 18:47
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Emulator.Common;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Protocol.Enums;
using Emulator.Common.Protocol.Net.Messages;
using Emulator.Common.Protocol.Net.Messages.Connection;
using Emulator.Common.Protocol.Net.Types;
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

        [MessageHandler(ServerSelectionMessage.ID)]
        public void HandleServerSelectionMessage(ServerSelectionMessage message)
        {
            if (!SelectServer(message.ServerId))
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
                            Id = (ushort)server.Id,
                            Completion = 0,
                            Status = (sbyte)server.Status,
                            IsSelectable = true,
                            Date = 0,
                            CharactersCount = (sbyte)client.Account.Characters.Where(a => a.ServerId == server.Id).ToArray().Length
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
                Address = server.Ip,
                Port = (ushort)server.Port,
                CanCreateNewCharacter = true,
                ServerId = (short)server.Id,
                Ticket = ticket
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
                    Id = (ushort)server.Id,
                    Completion = 0,
                    Status = (sbyte)server.Status,
                    IsSelectable = true,
                    Date = 0,
                    CharactersCount = (sbyte)client.Account.Characters.Where(a => a.ServerId == server.Id).ToArray().Length
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
