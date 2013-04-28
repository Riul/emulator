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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class SetUpdateMessage : NetworkMessage
    {
        public const uint ID = 5503;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short SetId { get; set; }
        public short[] SetObjects { get; set; }
        public ObjectEffect[] SetEffects { get; set; }


        public SetUpdateMessage()
        {
        }

        public SetUpdateMessage(short setId, short[] setObjects, ObjectEffect[] setEffects)
        {
            SetId = setId;
            SetObjects = setObjects;
            SetEffects = setEffects;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(SetId);
            writer.WriteUShort((ushort) SetObjects.Length);
            foreach (var entry in SetObjects)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) SetEffects.Length);
            foreach (var entry in SetEffects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            SetId = reader.ReadShort();
            var limit = reader.ReadUShort();
            SetObjects = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                SetObjects[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            SetEffects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                SetEffects[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                SetEffects[i].Deserialize(reader);
            }
        }
    }
}