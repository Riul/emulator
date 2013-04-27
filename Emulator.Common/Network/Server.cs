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
// Created on 26/04/2013 at 16:44
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
