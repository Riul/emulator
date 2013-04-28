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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Paddock
{
    public class PaddockToSellFilterMessage : NetworkMessage
    {
        public const uint ID = 6161;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int AreaId { get; set; }
        public sbyte AtLeastNbMount { get; set; }
        public sbyte AtLeastNbMachine { get; set; }
        public int MaxPrice { get; set; }


        public PaddockToSellFilterMessage()
        {
        }

        public PaddockToSellFilterMessage(int areaId, sbyte atLeastNbMount, sbyte atLeastNbMachine, int maxPrice)
        {
            AreaId = areaId;
            AtLeastNbMount = atLeastNbMount;
            AtLeastNbMachine = atLeastNbMachine;
            MaxPrice = maxPrice;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(AreaId);
            writer.WriteSByte(AtLeastNbMount);
            writer.WriteSByte(AtLeastNbMachine);
            writer.WriteInt(MaxPrice);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            AreaId = reader.ReadInt();
            AtLeastNbMount = reader.ReadSByte();
            AtLeastNbMachine = reader.ReadSByte();
            MaxPrice = reader.ReadInt();
        }
    }
}