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

namespace Emulator.Common.Protocol.Net.Types.Game.Guild.Tax
{
    public class TaxCollectorBasicInformations
    {
        public const short ID = 96;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short FirstNameId { get; set; }
        public short LastNameId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }


        public TaxCollectorBasicInformations()
        {
        }

        public TaxCollectorBasicInformations(short firstNameId, short lastNameId, short worldX, short worldY, int mapId, short subAreaId)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(FirstNameId);
            writer.WriteShort(LastNameId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            FirstNameId = reader.ReadShort();
            LastNameId = reader.ReadShort();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
        }
    }
}