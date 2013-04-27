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
    public class AbstractPartyMessage : NetworkMessage
    {
        public const uint Id = 6274;

        public int partyId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public AbstractPartyMessage()
        {
        }

        public AbstractPartyMessage(int partyId)
        {
            this.partyId = partyId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(partyId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            partyId = reader.ReadInt();
            if (partyId < 0)
                throw new Exception("Forbidden value on partyId = " + partyId + ", it doesn't respect the following condition : partyId < 0");
        }
    }
}