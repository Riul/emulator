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
//     Created on 26/04/2013 at 16:44
// */
#endregion

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Emulator.Common.Network
{
    public delegate void ClientConnectedEventHandler(object sender, TcpClient client);

    public class Server
    {
        public Server(int port)
        {
            Port = port;
            Socket = new TcpListener(IPAddress.Any, Port);
        }

        public TcpListener Socket { get; private set; }
        public int Port { get; private set; }
        public bool Running { get; private set; }

        public event ClientConnectedEventHandler ClientConnected;

        /// <summary>
        /// Starts the server
        /// </summary>
        public void Start()
        {
            if (Running)
                throw new Exception("The server is already running.");
            Socket.Start();
            Running = true;

            new Task(Listen).Start();
        }

        /// <summary>
        /// Stops the server and disconnect all the clients
        /// </summary>
        public void Stop()
        {
            if (!Running)
                throw new Exception("The server isn't running.");
            Socket.Stop();
            Running = false;
        }

        protected virtual void OnClientConnected(TcpClient client)
        {
            ClientConnectedEventHandler handler = ClientConnected;
            if (handler != null) handler(this, client);
        }

        private void Listen()
        {
            while (Running)
            {
                Thread.Sleep(5);
                if (Socket.Pending())
                {
                    OnClientConnected(Socket.AcceptTcpClient());
                }
            }
        }
    }
}
