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
    public class PaddockInformationsForSell
    {
        public const short ID = 222;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public string GuildOwner { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public short SubAreaId { get; set; }
        public sbyte NbMount { get; set; }
        public sbyte NbObject { get; set; }
        public int Price { get; set; }


        public PaddockInformationsForSell()
        {
        }

        public PaddockInformationsForSell(string guildOwner, short worldX, short worldY, short subAreaId, sbyte nbMount, sbyte nbObject, int price)
        {
            GuildOwner = guildOwner;
            WorldX = worldX;
            WorldY = worldY;
            SubAreaId = subAreaId;
            NbMount = nbMount;
            NbObject = nbObject;
            Price = price;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(GuildOwner);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteShort(SubAreaId);
            writer.WriteSByte(NbMount);
            writer.WriteSByte(NbObject);
            writer.WriteInt(Price);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            GuildOwner = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadShort();
            NbMount = reader.ReadSByte();
            NbObject = reader.ReadSByte();
            Price = reader.ReadInt();
        }
    }
}