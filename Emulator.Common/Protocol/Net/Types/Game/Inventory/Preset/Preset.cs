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

namespace Emulator.Common.Protocol.Net.Types.Game.Inventory.Preset
{
    public class Preset
    {
        public const short ID = 355;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte PresetId { get; set; }
        public sbyte SymbolId { get; set; }
        public bool Mount { get; set; }
        public PresetItem[] Objects { get; set; }


        public Preset()
        {
        }

        public Preset(sbyte presetId, sbyte symbolId, bool mount, PresetItem[] objects)
        {
            PresetId = presetId;
            SymbolId = symbolId;
            Mount = mount;
            Objects = objects;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(PresetId);
            writer.WriteSByte(SymbolId);
            writer.WriteBoolean(Mount);
            writer.WriteUShort((ushort) Objects.Length);
            foreach (var entry in Objects)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            PresetId = reader.ReadSByte();
            SymbolId = reader.ReadSByte();
            Mount = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            Objects = new PresetItem[limit];
            for (int i = 0; i < limit; i++)
            {
                Objects[i] = new PresetItem();
                Objects[i].Deserialize(reader);
            }
        }
    }
}