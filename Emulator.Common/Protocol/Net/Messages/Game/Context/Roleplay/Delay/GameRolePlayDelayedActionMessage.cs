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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Delay
{
    public class GameRolePlayDelayedActionMessage : NetworkMessage
    {
        public const uint Id = 6153;

        public int delayDuration;
        public sbyte delayTypeId;
        public int delayedCharacterId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameRolePlayDelayedActionMessage()
        {
        }

        public GameRolePlayDelayedActionMessage(int delayedCharacterId, sbyte delayTypeId, int delayDuration)
        {
            this.delayedCharacterId = delayedCharacterId;
            this.delayTypeId = delayTypeId;
            this.delayDuration = delayDuration;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(delayedCharacterId);
            writer.WriteSByte(delayTypeId);
            writer.WriteInt(delayDuration);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            delayedCharacterId = reader.ReadInt();
            delayTypeId = reader.ReadSByte();
            if (delayTypeId < 0)
                throw new Exception("Forbidden value on delayTypeId = " + delayTypeId + ", it doesn't respect the following condition : delayTypeId < 0");
            delayDuration = reader.ReadInt();
            if (delayDuration < 0)
                throw new Exception("Forbidden value on delayDuration = " + delayDuration + ", it doesn't respect the following condition : delayDuration < 0");
        }
    }
}