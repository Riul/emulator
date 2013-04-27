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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class SetUpdateMessage : NetworkMessage
    {
        public const uint Id = 5503;
        public ObjectEffect[] setEffects;

        public short setId;
        public short[] setObjects;

        public override uint MessageId
        {
            get { return Id; }
        }


        public SetUpdateMessage()
        {
        }

        public SetUpdateMessage(short setId, short[] setObjects, ObjectEffect[] setEffects)
        {
            this.setId = setId;
            this.setObjects = setObjects;
            this.setEffects = setEffects;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(setId);
            writer.WriteUShort((ushort) setObjects.Length);
            foreach (var entry in setObjects)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) setEffects.Length);
            foreach (var entry in setEffects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            setId = reader.ReadShort();
            if (setId < 0)
                throw new Exception("Forbidden value on setId = " + setId + ", it doesn't respect the following condition : setId < 0");
            var limit = reader.ReadUShort();
            setObjects = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                setObjects[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            setEffects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                setEffects[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                setEffects[i].Deserialize(reader);
            }
        }
    }
}