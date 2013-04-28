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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyJoinMessage : AbstractPartyMessage
    {
        public const uint ID = 5576;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte PartyType { get; set; }
        public int PartyLeaderId { get; set; }
        public sbyte MaxParticipants { get; set; }
        public PartyMemberInformations[] Members { get; set; }
        public PartyGuestInformations[] Guests { get; set; }
        public bool Restricted { get; set; }


        public PartyJoinMessage()
        {
        }

        public PartyJoinMessage(int partyId, sbyte partyType, int partyLeaderId, sbyte maxParticipants, PartyMemberInformations[] members, PartyGuestInformations[] guests, bool restricted)
                : base(partyId)
        {
            PartyType = partyType;
            PartyLeaderId = partyLeaderId;
            MaxParticipants = maxParticipants;
            Members = members;
            Guests = guests;
            Restricted = restricted;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PartyType);
            writer.WriteInt(PartyLeaderId);
            writer.WriteSByte(MaxParticipants);
            writer.WriteUShort((ushort) Members.Length);
            foreach (var entry in Members)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) Guests.Length);
            foreach (var entry in Guests)
            {
                entry.Serialize(writer);
            }
            writer.WriteBoolean(Restricted);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadSByte();
            PartyLeaderId = reader.ReadInt();
            MaxParticipants = reader.ReadSByte();
            var limit = reader.ReadUShort();
            Members = new PartyMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Members[i] = Types.ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
                Members[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            Guests = new PartyGuestInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Guests[i] = new PartyGuestInformations();
                Guests[i].Deserialize(reader);
            }
            Restricted = reader.ReadBoolean();
        }
    }
}