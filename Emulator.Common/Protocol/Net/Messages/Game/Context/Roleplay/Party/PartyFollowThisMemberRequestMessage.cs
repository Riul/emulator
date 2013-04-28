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
    public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
    {
        public const uint ID = 5588;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool Enabled { get; set; }


        public PartyFollowThisMemberRequestMessage()
        {
        }

        public PartyFollowThisMemberRequestMessage(int partyId, int playerId, bool enabled)
                : base(partyId, playerId)
        {
            Enabled = enabled;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Enabled = reader.ReadBoolean();
        }
    }
}