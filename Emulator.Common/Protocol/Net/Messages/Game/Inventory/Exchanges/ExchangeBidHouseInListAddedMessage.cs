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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseInListAddedMessage : NetworkMessage
    {
        public const uint ID = 5949;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int ItemUID { get; set; }
        public int ObjGenericId { get; set; }
        public short PowerRate { get; set; }
        public bool OverMax { get; set; }
        public ObjectEffect[] Effects { get; set; }
        public int[] Prices { get; set; }


        public ExchangeBidHouseInListAddedMessage()
        {
        }

        public ExchangeBidHouseInListAddedMessage(int itemUID, int objGenericId, short powerRate, bool overMax, ObjectEffect[] effects, int[] prices)
        {
            ItemUID = itemUID;
            ObjGenericId = objGenericId;
            PowerRate = powerRate;
            OverMax = overMax;
            Effects = effects;
            Prices = prices;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(ItemUID);
            writer.WriteInt(ObjGenericId);
            writer.WriteShort(PowerRate);
            writer.WriteBoolean(OverMax);
            writer.WriteUShort((ushort) Effects.Length);
            foreach (var entry in Effects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) Prices.Length);
            foreach (var entry in Prices)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ItemUID = reader.ReadInt();
            ObjGenericId = reader.ReadInt();
            PowerRate = reader.ReadShort();
            OverMax = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            Effects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                Effects[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                Effects[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            Prices = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                Prices[i] = reader.ReadInt();
            }
        }
    }
}