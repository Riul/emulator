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

namespace Emulator.Common.Protocol.Net.Messages.Game.Approach
{
    public class AccountCapabilitiesMessage : NetworkMessage
    {
        public const uint Id = 6216;

        public int accountId;
        public short breedsAvailable;
        public short breedsVisible;
        public sbyte status;
        public bool tutorialAvailable;


        public AccountCapabilitiesMessage()
        {
        }

        public AccountCapabilitiesMessage(int accountId, bool tutorialAvailable, short breedsVisible, short breedsAvailable, sbyte status)
        {
            this.accountId = accountId;
            this.tutorialAvailable = tutorialAvailable;
            this.breedsVisible = breedsVisible;
            this.breedsAvailable = breedsAvailable;
            this.status = status;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(accountId);
            writer.WriteBoolean(tutorialAvailable);
            writer.WriteShort(breedsVisible);
            writer.WriteShort(breedsAvailable);
            writer.WriteSByte(status);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            accountId = reader.ReadInt();
            tutorialAvailable = reader.ReadBoolean();
            breedsVisible = reader.ReadShort();
            if (breedsVisible < 0)
                throw new Exception("Forbidden value on breedsVisible = " + breedsVisible + ", it doesn't respect the following condition : breedsVisible < 0");
            breedsAvailable = reader.ReadShort();
            if (breedsAvailable < 0)
                throw new Exception("Forbidden value on breedsAvailable = " + breedsAvailable + ", it doesn't respect the following condition : breedsAvailable < 0");
            status = reader.ReadSByte();
        }
    }
}