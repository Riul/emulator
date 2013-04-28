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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class LivingObjectMessageMessage : NetworkMessage
    {
        public const uint ID = 6065;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short MsgId { get; set; }
        public uint TimeStamp { get; set; }
        public string Owner { get; set; }
        public uint ObjectGenericId { get; set; }


        public LivingObjectMessageMessage()
        {
        }

        public LivingObjectMessageMessage(short msgId, uint timeStamp, string owner, uint objectGenericId)
        {
            MsgId = msgId;
            TimeStamp = timeStamp;
            Owner = owner;
            ObjectGenericId = objectGenericId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(MsgId);
            writer.WriteUInt(TimeStamp);
            writer.WriteUTF(Owner);
            writer.WriteUInt(ObjectGenericId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            MsgId = reader.ReadShort();
            TimeStamp = reader.ReadUInt();
            Owner = reader.ReadUTF();
            ObjectGenericId = reader.ReadUInt();
        }
    }
}