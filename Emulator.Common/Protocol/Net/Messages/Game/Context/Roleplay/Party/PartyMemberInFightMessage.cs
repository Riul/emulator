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
using Emulator.Common.Protocol.Net.Types.Game.Context;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyMemberInFightMessage : AbstractPartyMessage
    {
        public const uint ID = 6342;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte Reason { get; set; }
        public int MemberId { get; set; }
        public int MemberAccountId { get; set; }
        public string MemberName { get; set; }
        public int FightId { get; set; }
        public MapCoordinatesExtended FightMap { get; set; }
        public int SecondsBeforeFightStart { get; set; }


        public PartyMemberInFightMessage()
        {
        }

        public PartyMemberInFightMessage(int partyId, sbyte reason, int memberId, int memberAccountId, string memberName, int fightId, MapCoordinatesExtended fightMap, int secondsBeforeFightStart)
                : base(partyId)
        {
            Reason = reason;
            MemberId = memberId;
            MemberAccountId = memberAccountId;
            MemberName = memberName;
            FightId = fightId;
            FightMap = fightMap;
            SecondsBeforeFightStart = secondsBeforeFightStart;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Reason);
            writer.WriteInt(MemberId);
            writer.WriteInt(MemberAccountId);
            writer.WriteUTF(MemberName);
            writer.WriteInt(FightId);
            FightMap.Serialize(writer);
            writer.WriteInt(SecondsBeforeFightStart);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadSByte();
            MemberId = reader.ReadInt();
            MemberAccountId = reader.ReadInt();
            MemberName = reader.ReadUTF();
            FightId = reader.ReadInt();
            FightMap = new MapCoordinatesExtended();
            FightMap.Deserialize(reader);
            SecondsBeforeFightStart = reader.ReadInt();
        }
    }
}