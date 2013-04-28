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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyInvitationMessage : AbstractPartyMessage
    {
        public const uint ID = 5586;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte PartyType { get; set; }
        public sbyte MaxParticipants { get; set; }
        public int FromId { get; set; }
        public string FromName { get; set; }
        public int ToId { get; set; }


        public PartyInvitationMessage()
        {
        }

        public PartyInvitationMessage(int partyId, sbyte partyType, sbyte maxParticipants, int fromId, string fromName, int toId)
                : base(partyId)
        {
            PartyType = partyType;
            MaxParticipants = maxParticipants;
            FromId = fromId;
            FromName = fromName;
            ToId = toId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PartyType);
            writer.WriteSByte(MaxParticipants);
            writer.WriteInt(FromId);
            writer.WriteUTF(FromName);
            writer.WriteInt(ToId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadSByte();
            MaxParticipants = reader.ReadSByte();
            FromId = reader.ReadInt();
            FromName = reader.ReadUTF();
            ToId = reader.ReadInt();
        }
    }
}