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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items
{
    public class SellerBuyerDescriptor
    {
        public const short Id = 121;

        public int maxItemLevel;
        public int maxItemPerAccount;
        public int npcContextualId;
        public int[] quantities;
        public float taxPercentage;
        public int[] types;
        public short unsoldDelay;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public SellerBuyerDescriptor()
        {
        }

        public SellerBuyerDescriptor(int[] quantities, int[] types, float taxPercentage, int maxItemLevel, int maxItemPerAccount, int npcContextualId, short unsoldDelay)
        {
            this.quantities = quantities;
            this.types = types;
            this.taxPercentage = taxPercentage;
            this.maxItemLevel = maxItemLevel;
            this.maxItemPerAccount = maxItemPerAccount;
            this.npcContextualId = npcContextualId;
            this.unsoldDelay = unsoldDelay;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) quantities.Length);
            foreach (var entry in quantities)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) types.Length);
            foreach (var entry in types)
            {
                writer.WriteInt(entry);
            }
            writer.WriteFloat(taxPercentage);
            writer.WriteInt(maxItemLevel);
            writer.WriteInt(maxItemPerAccount);
            writer.WriteInt(npcContextualId);
            writer.WriteShort(unsoldDelay);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            quantities = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                quantities[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            types = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                types[i] = reader.ReadInt();
            }
            taxPercentage = reader.ReadFloat();
            maxItemLevel = reader.ReadInt();
            if (maxItemLevel < 0)
                throw new Exception("Forbidden value on maxItemLevel = " + maxItemLevel + ", it doesn't respect the following condition : maxItemLevel < 0");
            maxItemPerAccount = reader.ReadInt();
            if (maxItemPerAccount < 0)
                throw new Exception("Forbidden value on maxItemPerAccount = " + maxItemPerAccount + ", it doesn't respect the following condition : maxItemPerAccount < 0");
            npcContextualId = reader.ReadInt();
            unsoldDelay = reader.ReadShort();
            if (unsoldDelay < 0)
                throw new Exception("Forbidden value on unsoldDelay = " + unsoldDelay + ", it doesn't respect the following condition : unsoldDelay < 0");
        }
    }
}