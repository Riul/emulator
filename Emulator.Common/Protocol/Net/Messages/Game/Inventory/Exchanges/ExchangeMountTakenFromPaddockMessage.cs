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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeMountTakenFromPaddockMessage : NetworkMessage
    {
        public const uint ID = 5994;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string Name { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public string Ownername { get; set; }


        public ExchangeMountTakenFromPaddockMessage()
        {
        }

        public ExchangeMountTakenFromPaddockMessage(string name, short worldX, short worldY, string ownername)
        {
            Name = name;
            WorldX = worldX;
            WorldY = worldY;
            Ownername = ownername;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUTF(Ownername);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Name = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Ownername = reader.ReadUTF();
        }
    }
}