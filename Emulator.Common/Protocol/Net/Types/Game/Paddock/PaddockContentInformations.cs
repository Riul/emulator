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

namespace Emulator.Common.Protocol.Net.Types.Game.Paddock
{
    public class PaddockContentInformations : PaddockInformations
    {
        public const short Id = 183;
        public bool abandonned;
        public int mapId;
        public MountInformationsForPaddock[] mountsInformations;

        public int paddockId;
        public short subAreaId;
        public short worldX;
        public short worldY;

        public override short TypeId
        {
            get { return Id; }
        }


        public PaddockContentInformations()
        {
        }

        public PaddockContentInformations(short maxOutdoorMount, short maxItems, int paddockId, short worldX, short worldY, int mapId, short subAreaId, bool abandonned, MountInformationsForPaddock[] mountsInformations)
            : base(maxOutdoorMount, maxItems)
        {
            this.paddockId = paddockId;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.abandonned = abandonned;
            this.mountsInformations = mountsInformations;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(paddockId);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteShort(subAreaId);
            writer.WriteBoolean(abandonned);
            writer.WriteUShort((ushort) mountsInformations.Length);
            foreach (var entry in mountsInformations)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            paddockId = reader.ReadInt();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            abandonned = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            mountsInformations = new MountInformationsForPaddock[limit];
            for (int i = 0; i < limit; i++)
            {
                mountsInformations[i] = new MountInformationsForPaddock();
                mountsInformations[i].Deserialize(reader);
            }
        }
    }
}