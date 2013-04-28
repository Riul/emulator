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
    public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
    {
        public const uint ID = 6129;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int FirstCharacterId { get; set; }
        public int FirstCharacterCurrentWeight { get; set; }
        public int FirstCharacterMaxWeight { get; set; }
        public int SecondCharacterId { get; set; }
        public int SecondCharacterCurrentWeight { get; set; }
        public int SecondCharacterMaxWeight { get; set; }


        public ExchangeStartedWithPodsMessage()
        {
        }

        public ExchangeStartedWithPodsMessage(sbyte exchangeType, int firstCharacterId, int firstCharacterCurrentWeight, int firstCharacterMaxWeight, int secondCharacterId, int secondCharacterCurrentWeight, int secondCharacterMaxWeight)
                : base(exchangeType)
        {
            FirstCharacterId = firstCharacterId;
            FirstCharacterCurrentWeight = firstCharacterCurrentWeight;
            FirstCharacterMaxWeight = firstCharacterMaxWeight;
            SecondCharacterId = secondCharacterId;
            SecondCharacterCurrentWeight = secondCharacterCurrentWeight;
            SecondCharacterMaxWeight = secondCharacterMaxWeight;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(FirstCharacterId);
            writer.WriteInt(FirstCharacterCurrentWeight);
            writer.WriteInt(FirstCharacterMaxWeight);
            writer.WriteInt(SecondCharacterId);
            writer.WriteInt(SecondCharacterCurrentWeight);
            writer.WriteInt(SecondCharacterMaxWeight);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            FirstCharacterId = reader.ReadInt();
            FirstCharacterCurrentWeight = reader.ReadInt();
            FirstCharacterMaxWeight = reader.ReadInt();
            SecondCharacterId = reader.ReadInt();
            SecondCharacterCurrentWeight = reader.ReadInt();
            SecondCharacterMaxWeight = reader.ReadInt();
        }
    }
}