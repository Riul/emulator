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
    public class PartyInvitationDetailsMessage : AbstractPartyMessage
    {
        public const uint ID = 6263;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte PartyType { get; set; }
        public int FromId { get; set; }
        public string FromName { get; set; }
        public int LeaderId { get; set; }
        public PartyInvitationMemberInformations[] Members { get; set; }
        public PartyGuestInformations[] Guests { get; set; }


        public PartyInvitationDetailsMessage()
        {
        }

        public PartyInvitationDetailsMessage(int partyId, sbyte partyType, int fromId, string fromName, int leaderId, PartyInvitationMemberInformations[] members, PartyGuestInformations[] guests)
                : base(partyId)
        {
            PartyType = partyType;
            FromId = fromId;
            FromName = fromName;
            LeaderId = leaderId;
            Members = members;
            Guests = guests;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PartyType);
            writer.WriteInt(FromId);
            writer.WriteUTF(FromName);
            writer.WriteInt(LeaderId);
            writer.WriteUShort((ushort) Members.Length);
            foreach (var entry in Members)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) Guests.Length);
            foreach (var entry in Guests)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadSByte();
            FromId = reader.ReadInt();
            FromName = reader.ReadUTF();
            LeaderId = reader.ReadInt();
            var limit = reader.ReadUShort();
            Members = new PartyInvitationMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Members[i] = new PartyInvitationMemberInformations();
                Members[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            Guests = new PartyGuestInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Guests[i] = new PartyGuestInformations();
                Guests[i].Deserialize(reader);
            }
        }
    }
}