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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Look
{
    public class EntityLook
    {
        public const short Id = 55;

        public short bonesId;
        public int[] indexedColors;
        public short[] scales;
        public short[] skins;
        public SubEntity[] subentities;


        public EntityLook()
        {
            skins = new short[0];
            indexedColors = new int[0];
            scales = new short[0];
            subentities = new SubEntity[0];
        }

        public EntityLook(short bonesId, short[] skins, int[] indexedColors, short[] scales, SubEntity[] subentities)
        {
            this.bonesId = bonesId;
            this.skins = skins;
            this.indexedColors = indexedColors;
            this.scales = scales;
            this.subentities = subentities;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(bonesId);
            writer.WriteUShort((ushort) skins.Length);
            foreach (var entry in skins)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) indexedColors.Length);
            foreach (var entry in indexedColors)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) scales.Length);
            foreach (var entry in scales)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) subentities.Length);
            foreach (var entry in subentities)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            bonesId = reader.ReadShort();
            if (bonesId < 0)
                throw new Exception("Forbidden value on bonesId = " + bonesId + ", it doesn't respect the following condition : bonesId < 0");
            var limit = reader.ReadUShort();
            skins = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                skins[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            indexedColors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                indexedColors[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            scales = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                scales[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            subentities = new SubEntity[limit];
            for (int i = 0; i < limit; i++)
            {
                subentities[i] = new SubEntity();
                subentities[i].Deserialize(reader);
            }
        }
    }
}