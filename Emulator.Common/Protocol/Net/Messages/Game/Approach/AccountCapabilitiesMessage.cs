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

namespace Emulator.Common.Protocol.Net.Messages.Game.Approach
{
    public class AccountCapabilitiesMessage : NetworkMessage
    {
        public const uint ID = 6216;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int AccountId { get; set; }
        public bool TutorialAvailable { get; set; }
        public short BreedsVisible { get; set; }
        public short BreedsAvailable { get; set; }
        public sbyte Status { get; set; }


        public AccountCapabilitiesMessage()
        {
        }

        public AccountCapabilitiesMessage(int accountId, bool tutorialAvailable, short breedsVisible, short breedsAvailable, sbyte status)
        {
            AccountId = accountId;
            TutorialAvailable = tutorialAvailable;
            BreedsVisible = breedsVisible;
            BreedsAvailable = breedsAvailable;
            Status = status;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteBoolean(TutorialAvailable);
            writer.WriteShort(BreedsVisible);
            writer.WriteShort(BreedsAvailable);
            writer.WriteSByte(Status);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            AccountId = reader.ReadInt();
            TutorialAvailable = reader.ReadBoolean();
            BreedsVisible = reader.ReadShort();
            BreedsAvailable = reader.ReadShort();
            Status = reader.ReadSByte();
        }
    }
}