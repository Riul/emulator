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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class LivingObjectMessageMessage : NetworkMessage
    {
        public const uint Id = 6065;

        public short msgId;
        public uint objectGenericId;
        public string owner;
        public uint timeStamp;

        public override uint MessageId
        {
            get { return Id; }
        }


        public LivingObjectMessageMessage()
        {
        }

        public LivingObjectMessageMessage(short msgId, uint timeStamp, string owner, uint objectGenericId)
        {
            this.msgId = msgId;
            this.timeStamp = timeStamp;
            this.owner = owner;
            this.objectGenericId = objectGenericId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(msgId);
            writer.WriteUInt(timeStamp);
            writer.WriteUTF(owner);
            writer.WriteUInt(objectGenericId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            msgId = reader.ReadShort();
            if (msgId < 0)
                throw new Exception("Forbidden value on msgId = " + msgId + ", it doesn't respect the following condition : msgId < 0");
            timeStamp = reader.ReadUInt();
            if (timeStamp < 0 || timeStamp > 4294967295)
                throw new Exception("Forbidden value on timeStamp = " + timeStamp + ", it doesn't respect the following condition : timeStamp < 0 || timeStamp > 4294967295");
            owner = reader.ReadUTF();
            objectGenericId = reader.ReadUInt();
            if (objectGenericId < 0 || objectGenericId > 4294967295)
                throw new Exception("Forbidden value on objectGenericId = " + objectGenericId + ", it doesn't respect the following condition : objectGenericId < 0 || objectGenericId > 4294967295");
        }
    }
}