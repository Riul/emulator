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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Lockable
{
    public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
    {
        public const uint Id = 5669;

        public int elementId;
        public int mapId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public LockableStateUpdateStorageMessage()
        {
        }

        public LockableStateUpdateStorageMessage(bool locked, int mapId, int elementId)
            : base(locked)
        {
            this.mapId = mapId;
            this.elementId = elementId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(mapId);
            writer.WriteInt(elementId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            mapId = reader.ReadInt();
            elementId = reader.ReadInt();
            if (elementId < 0)
                throw new Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
        }
    }
}