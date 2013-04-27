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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Authorized
{
    public class ConsoleCommandsListMessage : NetworkMessage
    {
        public const uint Id = 6127;

        public string[] aliases;
        public string[] arguments;
        public string[] descriptions;


        public ConsoleCommandsListMessage()
        {
        }

        public ConsoleCommandsListMessage(string[] aliases, string[] arguments, string[] descriptions)
        {
            this.aliases = aliases;
            this.arguments = arguments;
            this.descriptions = descriptions;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) aliases.Length);
            foreach (var entry in aliases)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) arguments.Length);
            foreach (var entry in arguments)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) descriptions.Length);
            foreach (var entry in descriptions)
            {
                writer.WriteUTF(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            aliases = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                aliases[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            arguments = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                arguments[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            descriptions = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                descriptions[i] = reader.ReadUTF();
            }
        }
    }
}