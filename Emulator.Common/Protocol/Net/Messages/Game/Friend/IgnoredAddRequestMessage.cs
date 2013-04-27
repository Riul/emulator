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

namespace Emulator.Common.Protocol.Net.Messages.Game.Friend
{
    public class IgnoredAddRequestMessage : NetworkMessage
    {
        public const uint Id = 5673;

        public string name;
        public bool session;


        public IgnoredAddRequestMessage()
        {
        }

        public IgnoredAddRequestMessage(string name, bool session)
        {
            this.name = name;
            this.session = session;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteBoolean(session);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            name = reader.ReadUTF();
            session = reader.ReadBoolean();
        }
    }
}