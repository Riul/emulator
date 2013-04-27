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
//     Created on 26/04/2013 at 16:43
// */
#endregion

using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Emulator.Common.IO;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Protocol.Net;
using Emulator.Common.Protocol.Net.Messages;

namespace Emulator.Common.Network
{
    public delegate void MessageReceivedEventHandler(object sender, NetworkMessage message);

    public class Client
    {
        private readonly object locker;

        public Client()
        {
            locker = new object();
            Socket = new TcpClient();
            Dispatcher = new Dispatcher(this);
        }

        public Client(TcpClient client)
        {
            locker = new object();
            Socket = client;
            Running = true;
            Dispatcher = new Dispatcher(this);

            Reader = new BigEndianReader(Socket.GetStream());
            Writer = new BigEndianWriter(Socket.GetStream());
            new Task(Listen).Start();
        }

        public Dispatcher Dispatcher { get; private set; }
        public TcpClient Socket { get; private set; }
        public bool Running { get; private set; }
        public BigEndianWriter Writer { get; private set; }
        public BigEndianReader Reader { get; private set; }

        public bool Connected
        {
            get { return Socket != null && Socket.Connected; }
        }

        public event MessageReceivedEventHandler MessageReceived;
        public event Action<Client> ClientConnected;
        public event Action<Client> ClientDisconnected;

        /// <summary>
        /// Connects the client to the specified port on the specified host.
        /// </summary>
        /// <param name="hostname">The DNS name of the remote host to which you intend to connect.</param>
        /// <param name="port">The port number of the remote host to which you intend to connect.</param>
        public bool Start(string hostname, int port)
        {
            if(Running)
                throw new Exception("The client is already running.");
            try
            {
                Socket.Connect(hostname, port);
            }
            catch (Exception)
            {
                return false;
            }
            Reader = new BigEndianReader(Socket.GetStream());
            Writer = new BigEndianWriter(Socket.GetStream());
            Running = true;

            new Task(Listen).Start();
            return true;
        }

        /// <summary>
        /// Disposes the socket instance and requests that the underlying TCP connection be closed.
        /// </summary>
        public void Stop()
        {
            if(!Running)
                throw new Exception("The client isn't running.");
            Socket.GetStream().Close();
            Socket.Close();
            Running = false;
        }

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        public void Send(NetworkMessage message)
        {
            lock (locker)
            {
                if(!Connected)
                    throw new Exception("Cannot send a message if the client isn't connected.");
                using (BigEndianWriter writer = new BigEndianWriter())
                {
                    message.Pack(writer);
                    Writer.WriteBytes(writer.Data);
                }
            }
        }

        protected virtual void OnMessageReceived(NetworkMessage message)
        {
            MessageReceivedEventHandler handler = MessageReceived;
            Logger.Debug("- " + message.GetType().Name);
            if (handler != null) handler(this, message);
        }

        protected virtual void OnClientDisconnected()
        {
            Running = false;
            Action<Client> handler = ClientDisconnected;
            if (handler != null) handler(this);
        }

        protected virtual void OnClientConnected()
        {
            Running = true;
            Action<Client> handler = ClientConnected;
            if (handler != null) handler(this);
        }

        private void Listen()
        {
            OnClientConnected();

            while (Running && Connected)
            {
                try
                {
                    Thread.Sleep(50);
                    OnMessageReceived(MessageBuilder.Build(Reader));
                }
                catch (Exception)
                {
                    break;
                }
            }

            Running = false;
            OnClientDisconnected();
        }
    }
}
