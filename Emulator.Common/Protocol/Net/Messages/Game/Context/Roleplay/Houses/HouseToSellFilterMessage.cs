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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Houses
{
    public class HouseToSellFilterMessage : NetworkMessage
    {
        public const uint ID = 6137;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int AreaId { get; set; }
        public sbyte AtLeastNbRoom { get; set; }
        public sbyte AtLeastNbChest { get; set; }
        public short SkillRequested { get; set; }
        public int MaxPrice { get; set; }


        public HouseToSellFilterMessage()
        {
        }

        public HouseToSellFilterMessage(int areaId, sbyte atLeastNbRoom, sbyte atLeastNbChest, short skillRequested, int maxPrice)
        {
            AreaId = areaId;
            AtLeastNbRoom = atLeastNbRoom;
            AtLeastNbChest = atLeastNbChest;
            SkillRequested = skillRequested;
            MaxPrice = maxPrice;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(AreaId);
            writer.WriteSByte(AtLeastNbRoom);
            writer.WriteSByte(AtLeastNbChest);
            writer.WriteShort(SkillRequested);
            writer.WriteInt(MaxPrice);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            AreaId = reader.ReadInt();
            AtLeastNbRoom = reader.ReadSByte();
            AtLeastNbChest = reader.ReadSByte();
            SkillRequested = reader.ReadShort();
            MaxPrice = reader.ReadInt();
        }
    }
}