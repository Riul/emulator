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
//     Created on 26/04/2013 at 16:45
// */
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Server.Basic
{
    public class SystemMessageDisplayMessage : NetworkMessage
    {
        public const uint Id = 189;

        public bool hangUp;
        public short msgId;
        public string[] parameters;


        public SystemMessageDisplayMessage()
        {
        }

        public SystemMessageDisplayMessage(bool hangUp, short msgId, string[] parameters)
        {
            this.hangUp = hangUp;
            this.msgId = msgId;
            this.parameters = parameters;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(hangUp);
            writer.WriteShort(msgId);
            writer.WriteUShort((ushort) parameters.Length);
            foreach (var entry in parameters)
            {
                writer.WriteUTF(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            hangUp = reader.ReadBoolean();
            msgId = reader.ReadShort();
            if (msgId < 0)
                throw new Exception("Forbidden value on msgId = " + msgId + ", it doesn't respect the following condition : msgId < 0");
            var limit = reader.ReadUShort();
            parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                parameters[i] = reader.ReadUTF();
            }
        }
    }
}