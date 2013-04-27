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
// Created on 26/04/2013 at 18:25
#endregion

using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Emulator.Common.Protocol.Net.Messages.Queues;
using Emulator.Login.Network;

namespace Emulator.Login.Managers
{
    public class QueueManager
    {
        public const int WAITING_TIME = 500;
        private static QueueManager _instance;
        private readonly Queue<AuthClient> queue;
        private readonly Timer timer;

        private QueueManager()
        {
            queue = new Queue<AuthClient>();
            timer = new Timer(WAITING_TIME);
            timer.Elapsed += Process;
            timer.Start();
        }

        public static QueueManager Instance
        {
            get { return _instance ?? (_instance = new QueueManager()); }
        }

        public void Enqueue(AuthClient client)
        {
            client.State = AuthClientStateEnum.IN_QUEUE;
            queue.Enqueue(client);
            UpdatePosition();
        }

        public void Dequeue(AuthClient client)
        {
            client.Authentification.CheckAccount();
        }

        public int GetPosition(AuthClient client)
        {
            if (queue.ToList().Contains(client))
            {
                return queue.ToList().IndexOf(client);
            }
            return -1;
        }

        private void Process(object sender, ElapsedEventArgs e)
        {
            if (queue.Count > 0)
            {
                Dequeue(queue.Dequeue());
                UpdatePosition();
            }
        }

        private void UpdatePosition()
        {
            foreach (var client in Program.Server.Clients)
            {
                if (client.State == AuthClientStateEnum.IN_QUEUE)
                {
                    UpdatePosition(client);
                }
            }
        }

        private void UpdatePosition(AuthClient client)
        {
            if (queue.Count > 0)
            {
                client.Send(new LoginQueueStatusMessage((ushort)GetPosition(client), (ushort)queue.Count));
            }
        }
    }
}
