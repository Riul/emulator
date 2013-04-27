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
// Created on 26/04/2013 at 16:45
#endregion

using System;
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyJoinMessage : AbstractPartyMessage
    {
        public const uint Id = 5576;
        public PartyGuestInformations[] guests;

        public sbyte maxParticipants;
        public PartyMemberInformations[] members;
        public int partyLeaderId;
        public sbyte partyType;
        public bool restricted;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PartyJoinMessage()
        {
        }

        public PartyJoinMessage(int partyId, sbyte partyType, int partyLeaderId, sbyte maxParticipants, PartyMemberInformations[] members, PartyGuestInformations[] guests, bool restricted)
            : base(partyId)
        {
            this.partyType = partyType;
            this.partyLeaderId = partyLeaderId;
            this.maxParticipants = maxParticipants;
            this.members = members;
            this.guests = guests;
            this.restricted = restricted;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(partyType);
            writer.WriteInt(partyLeaderId);
            writer.WriteSByte(maxParticipants);
            writer.WriteUShort((ushort) members.Length);
            foreach (var entry in members)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) guests.Length);
            foreach (var entry in guests)
            {
                entry.Serialize(writer);
            }
            writer.WriteBoolean(restricted);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            partyType = reader.ReadSByte();
            if (partyType < 0)
                throw new Exception("Forbidden value on partyType = " + partyType + ", it doesn't respect the following condition : partyType < 0");
            partyLeaderId = reader.ReadInt();
            if (partyLeaderId < 0)
                throw new Exception("Forbidden value on partyLeaderId = " + partyLeaderId + ", it doesn't respect the following condition : partyLeaderId < 0");
            maxParticipants = reader.ReadSByte();
            if (maxParticipants < 0)
                throw new Exception("Forbidden value on maxParticipants = " + maxParticipants + ", it doesn't respect the following condition : maxParticipants < 0");
            var limit = reader.ReadUShort();
            members = new PartyMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                members[i] = Types.ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
                members[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            guests = new PartyGuestInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                guests[i] = new PartyGuestInformations();
                guests[i].Deserialize(reader);
            }
            restricted = reader.ReadBoolean();
        }
    }
}