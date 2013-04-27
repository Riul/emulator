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
using Emulator.Common.Protocol.Net.Types.Game.Guild;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildInformationsMemberUpdateMessage : NetworkMessage
    {
        public const uint Id = 5597;

        public GuildMember member;


        public GuildInformationsMemberUpdateMessage()
        {
        }

        public GuildInformationsMemberUpdateMessage(GuildMember member)
        {
            this.member = member;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            member.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            member = new GuildMember();
            member.Deserialize(reader);
        }
    }
}