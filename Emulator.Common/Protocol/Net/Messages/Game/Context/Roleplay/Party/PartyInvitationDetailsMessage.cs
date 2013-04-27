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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyInvitationDetailsMessage : AbstractPartyMessage
    {
        public const uint Id = 6263;

        public int fromId;
        public string fromName;
        public PartyGuestInformations[] guests;
        public int leaderId;
        public PartyInvitationMemberInformations[] members;
        public sbyte partyType;


        public PartyInvitationDetailsMessage()
        {
        }

        public PartyInvitationDetailsMessage(int partyId, sbyte partyType, int fromId, string fromName, int leaderId, PartyInvitationMemberInformations[] members, PartyGuestInformations[] guests)
            : base(partyId)
        {
            this.partyType = partyType;
            this.fromId = fromId;
            this.fromName = fromName;
            this.leaderId = leaderId;
            this.members = members;
            this.guests = guests;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(partyType);
            writer.WriteInt(fromId);
            writer.WriteUTF(fromName);
            writer.WriteInt(leaderId);
            writer.WriteUShort((ushort) members.Length);
            foreach (var entry in members)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) guests.Length);
            foreach (var entry in guests)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            partyType = reader.ReadSByte();
            if (partyType < 0)
                throw new Exception("Forbidden value on partyType = " + partyType + ", it doesn't respect the following condition : partyType < 0");
            fromId = reader.ReadInt();
            if (fromId < 0)
                throw new Exception("Forbidden value on fromId = " + fromId + ", it doesn't respect the following condition : fromId < 0");
            fromName = reader.ReadUTF();
            leaderId = reader.ReadInt();
            if (leaderId < 0)
                throw new Exception("Forbidden value on leaderId = " + leaderId + ", it doesn't respect the following condition : leaderId < 0");
            var limit = reader.ReadUShort();
            members = new PartyInvitationMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                members[i] = new PartyInvitationMemberInformations();
                members[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            guests = new PartyGuestInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                guests[i] = new PartyGuestInformations();
                guests[i].Deserialize(reader);
            }
        }
    }
}