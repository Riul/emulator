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

namespace Emulator.Common.Protocol.Net.Types.Game.Look
{
    public class EntityLook
    {
        public const short ID = 55;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short BonesId { get; set; }
        public short[] Skins { get; set; }
        public int[] IndexedColors { get; set; }
        public short[] Scales { get; set; }
        public SubEntity[] Subentities { get; set; }


        public EntityLook()
        {
        }

        public EntityLook(short bonesId, short[] skins, int[] indexedColors, short[] scales, SubEntity[] subentities)
        {
            BonesId = bonesId;
            Skins = skins;
            IndexedColors = indexedColors;
            Scales = scales;
            Subentities = subentities;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(BonesId);
            writer.WriteUShort((ushort) Skins.Length);
            foreach (var entry in Skins)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) IndexedColors.Length);
            foreach (var entry in IndexedColors)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) Scales.Length);
            foreach (var entry in Scales)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) Subentities.Length);
            foreach (var entry in Subentities)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            BonesId = reader.ReadShort();
            var limit = reader.ReadUShort();
            Skins = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Skins[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            IndexedColors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                IndexedColors[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            Scales = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Scales[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            Subentities = new SubEntity[limit];
            for (int i = 0; i < limit; i++)
            {
                Subentities[i] = new SubEntity();
                Subentities[i].Deserialize(reader);
            }
        }
    }
}