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

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items
{
    public class SellerBuyerDescriptor
    {
        public const short ID = 121;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int[] Quantities { get; set; }
        public int[] Types { get; set; }
        public float TaxPercentage { get; set; }
        public int MaxItemLevel { get; set; }
        public int MaxItemPerAccount { get; set; }
        public int NpcContextualId { get; set; }
        public short UnsoldDelay { get; set; }


        public SellerBuyerDescriptor()
        {
        }

        public SellerBuyerDescriptor(int[] quantities, int[] types, float taxPercentage, int maxItemLevel, int maxItemPerAccount, int npcContextualId, short unsoldDelay)
        {
            Quantities = quantities;
            Types = types;
            TaxPercentage = taxPercentage;
            MaxItemLevel = maxItemLevel;
            MaxItemPerAccount = maxItemPerAccount;
            NpcContextualId = npcContextualId;
            UnsoldDelay = unsoldDelay;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Quantities.Length);
            foreach (var entry in Quantities)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) Types.Length);
            foreach (var entry in Types)
            {
                writer.WriteInt(entry);
            }
            writer.WriteFloat(TaxPercentage);
            writer.WriteInt(MaxItemLevel);
            writer.WriteInt(MaxItemPerAccount);
            writer.WriteInt(NpcContextualId);
            writer.WriteShort(UnsoldDelay);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Quantities = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                Quantities[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            Types = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                Types[i] = reader.ReadInt();
            }
            TaxPercentage = reader.ReadFloat();
            MaxItemLevel = reader.ReadInt();
            MaxItemPerAccount = reader.ReadInt();
            NpcContextualId = reader.ReadInt();
            UnsoldDelay = reader.ReadShort();
        }
    }
}