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
//     Created on 26/04/2013 at 17:44
// */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Emulator.Common.Protocol.Net.Messages;

namespace Emulator.Common.Network.Dispatching
{
    public class Dispatcher
    {
        private readonly List<MethodHandler> methods;
        private Client client;

        public Dispatcher(Client client)
        {
            this.client = client;
            methods = new List<MethodHandler>();
            client.MessageReceived += Dispatch;
        }

        public void Register(object @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            Type type = @object.GetType();

            foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                MessageHandlerAttribute[] attributes = methodInfo.GetCustomAttributes<MessageHandlerAttribute>().ToArray();
                if (attributes.Length != 0)
                {
                    Register(methodInfo, @object, attributes);
                }
            }
        }

        public void Register(MethodInfo method, object instance, MessageHandlerAttribute[] attributes)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            if (attributes == null || attributes.Length == 0)
            {
                return;
            }

            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                throw new Exception(string.Format("Only one parameter is allowed to use the MessageHandler attribute. (method {0})", method.Name));
            }
            if (!parameters[0].ParameterType.IsSubclassOf(typeof(NetworkMessage)))
            {
                throw new Exception(string.Format("The parameter of a MessageHandler attribute must be a child of NetworkMessage. (method {0})", method.Name));
            }
            methods.Add(new MethodHandler(method, instance, attributes));
        }

        public void UnRegister(object @object)
        {
            methods.RemoveAll(entry => entry.Instance == @object);
        }

        private void Dispatch(object sender, NetworkMessage message)
        {
            foreach (var method in methods)
            {
                foreach (var attribute in method.Attributes)
                {
                    if (attribute.MessageId == message.MessageId || attribute.MessageType == message.GetType())
                    {
                        method.Invoke(message);
                    }
                }
            }
        }
    }
}
