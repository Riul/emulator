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
// Created on 26/04/2013 at 16:45
#endregion

using System;
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Npc
{
    public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
    {
        public const uint Id = 5615;
        public double experience;
        public int itemsValue;
        public int kamas;

        public short maxPods;
        public int pods;
        public short prospecting;
        public int taxCollectorAttack;
        public sbyte taxCollectorsCount;
        public short wisdom;

        public override uint MessageId
        {
            get { return Id; }
        }


        public TaxCollectorDialogQuestionExtendedMessage()
        {
        }

        public TaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations guildInfo, short maxPods, short prospecting, short wisdom, sbyte taxCollectorsCount, int taxCollectorAttack, int kamas, double experience, int pods, int itemsValue)
            : base(guildInfo)
        {
            this.maxPods = maxPods;
            this.prospecting = prospecting;
            this.wisdom = wisdom;
            this.taxCollectorsCount = taxCollectorsCount;
            this.taxCollectorAttack = taxCollectorAttack;
            this.kamas = kamas;
            this.experience = experience;
            this.pods = pods;
            this.itemsValue = itemsValue;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(maxPods);
            writer.WriteShort(prospecting);
            writer.WriteShort(wisdom);
            writer.WriteSByte(taxCollectorsCount);
            writer.WriteInt(taxCollectorAttack);
            writer.WriteInt(kamas);
            writer.WriteDouble(experience);
            writer.WriteInt(pods);
            writer.WriteInt(itemsValue);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            maxPods = reader.ReadShort();
            if (maxPods < 0)
                throw new Exception("Forbidden value on maxPods = " + maxPods + ", it doesn't respect the following condition : maxPods < 0");
            prospecting = reader.ReadShort();
            if (prospecting < 0)
                throw new Exception("Forbidden value on prospecting = " + prospecting + ", it doesn't respect the following condition : prospecting < 0");
            wisdom = reader.ReadShort();
            if (wisdom < 0)
                throw new Exception("Forbidden value on wisdom = " + wisdom + ", it doesn't respect the following condition : wisdom < 0");
            taxCollectorsCount = reader.ReadSByte();
            if (taxCollectorsCount < 0)
                throw new Exception("Forbidden value on taxCollectorsCount = " + taxCollectorsCount + ", it doesn't respect the following condition : taxCollectorsCount < 0");
            taxCollectorAttack = reader.ReadInt();
            kamas = reader.ReadInt();
            if (kamas < 0)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0");
            experience = reader.ReadDouble();
            if (experience < 0)
                throw new Exception("Forbidden value on experience = " + experience + ", it doesn't respect the following condition : experience < 0");
            pods = reader.ReadInt();
            if (pods < 0)
                throw new Exception("Forbidden value on pods = " + pods + ", it doesn't respect the following condition : pods < 0");
            itemsValue = reader.ReadInt();
            if (itemsValue < 0)
                throw new Exception("Forbidden value on itemsValue = " + itemsValue + ", it doesn't respect the following condition : itemsValue < 0");
        }
    }
}