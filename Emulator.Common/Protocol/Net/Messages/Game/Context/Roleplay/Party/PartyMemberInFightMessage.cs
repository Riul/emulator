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
using Emulator.Common.Protocol.Net.Types.Game.Context;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyMemberInFightMessage : AbstractPartyMessage
    {
        public const uint Id = 6342;

        public int fightId;
        public MapCoordinatesExtended fightMap;
        public int memberAccountId;
        public int memberId;
        public string memberName;
        public sbyte reason;
        public int secondsBeforeFightStart;


        public PartyMemberInFightMessage()
        {
        }

        public PartyMemberInFightMessage(int partyId, sbyte reason, int memberId, int memberAccountId, string memberName, int fightId, MapCoordinatesExtended fightMap, int secondsBeforeFightStart)
            : base(partyId)
        {
            this.reason = reason;
            this.memberId = memberId;
            this.memberAccountId = memberAccountId;
            this.memberName = memberName;
            this.fightId = fightId;
            this.fightMap = fightMap;
            this.secondsBeforeFightStart = secondsBeforeFightStart;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(reason);
            writer.WriteInt(memberId);
            writer.WriteInt(memberAccountId);
            writer.WriteUTF(memberName);
            writer.WriteInt(fightId);
            fightMap.Serialize(writer);
            writer.WriteInt(secondsBeforeFightStart);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            reason = reader.ReadSByte();
            if (reason < 0)
                throw new Exception("Forbidden value on reason = " + reason + ", it doesn't respect the following condition : reason < 0");
            memberId = reader.ReadInt();
            memberAccountId = reader.ReadInt();
            if (memberAccountId < 0)
                throw new Exception("Forbidden value on memberAccountId = " + memberAccountId + ", it doesn't respect the following condition : memberAccountId < 0");
            memberName = reader.ReadUTF();
            fightId = reader.ReadInt();
            fightMap = new MapCoordinatesExtended();
            fightMap.Deserialize(reader);
            secondsBeforeFightStart = reader.ReadInt();
        }
    }
}