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

namespace Emulator.Common.Protocol.Net.Types.Game.Paddock
{
    public class PaddockContentInformations : PaddockInformations
    {
        public const short ID = 183;

        public override short TypeId
        {
            get { return ID; }
        }

        public int PaddockId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }
        public bool Abandonned { get; set; }
        public MountInformationsForPaddock[] MountsInformations { get; set; }


        public PaddockContentInformations()
        {
        }

        public PaddockContentInformations(short maxOutdoorMount, short maxItems, int paddockId, short worldX, short worldY, int mapId, short subAreaId, bool abandonned, MountInformationsForPaddock[] mountsInformations)
                : base(maxOutdoorMount, maxItems)
        {
            PaddockId = paddockId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Abandonned = abandonned;
            MountsInformations = mountsInformations;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(PaddockId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
            writer.WriteBoolean(Abandonned);
            writer.WriteUShort((ushort) MountsInformations.Length);
            foreach (var entry in MountsInformations)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            PaddockId = reader.ReadInt();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
            Abandonned = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            MountsInformations = new MountInformationsForPaddock[limit];
            for (int i = 0; i < limit; i++)
            {
                MountsInformations[i] = new MountInformationsForPaddock();
                MountsInformations[i].Deserialize(reader);
            }
        }
    }
}