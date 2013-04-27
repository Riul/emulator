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
//     Created on 26/04/2013 at 18:25
// */
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
