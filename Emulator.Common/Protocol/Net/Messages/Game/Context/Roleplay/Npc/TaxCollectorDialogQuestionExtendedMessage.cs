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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Npc
{
    public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
    {
        public const uint ID = 5615;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short MaxPods { get; set; }
        public short Prospecting { get; set; }
        public short Wisdom { get; set; }
        public sbyte TaxCollectorsCount { get; set; }
        public int TaxCollectorAttack { get; set; }
        public int Kamas { get; set; }
        public double Experience { get; set; }
        public int Pods { get; set; }
        public int ItemsValue { get; set; }


        public TaxCollectorDialogQuestionExtendedMessage()
        {
        }

        public TaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations guildInfo, short maxPods, short prospecting, short wisdom, sbyte taxCollectorsCount, int taxCollectorAttack, int kamas, double experience, int pods, int itemsValue)
                : base(guildInfo)
        {
            MaxPods = maxPods;
            Prospecting = prospecting;
            Wisdom = wisdom;
            TaxCollectorsCount = taxCollectorsCount;
            TaxCollectorAttack = taxCollectorAttack;
            Kamas = kamas;
            Experience = experience;
            Pods = pods;
            ItemsValue = itemsValue;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MaxPods);
            writer.WriteShort(Prospecting);
            writer.WriteShort(Wisdom);
            writer.WriteSByte(TaxCollectorsCount);
            writer.WriteInt(TaxCollectorAttack);
            writer.WriteInt(Kamas);
            writer.WriteDouble(Experience);
            writer.WriteInt(Pods);
            writer.WriteInt(ItemsValue);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            MaxPods = reader.ReadShort();
            Prospecting = reader.ReadShort();
            Wisdom = reader.ReadShort();
            TaxCollectorsCount = reader.ReadSByte();
            TaxCollectorAttack = reader.ReadInt();
            Kamas = reader.ReadInt();
            Experience = reader.ReadDouble();
            Pods = reader.ReadInt();
            ItemsValue = reader.ReadInt();
        }
    }
}