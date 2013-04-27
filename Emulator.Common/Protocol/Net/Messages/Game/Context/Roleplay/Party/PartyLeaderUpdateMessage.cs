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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
    {
        public const uint Id = 5578;

        public int partyLeaderId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PartyLeaderUpdateMessage()
        {
        }

        public PartyLeaderUpdateMessage(int partyId, int partyLeaderId)
            : base(partyId)
        {
            this.partyLeaderId = partyLeaderId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(partyLeaderId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            partyLeaderId = reader.ReadInt();
            if (partyLeaderId < 0)
                throw new Exception("Forbidden value on partyLeaderId = " + partyLeaderId + ", it doesn't respect the following condition : partyLeaderId < 0");
        }
    }
}