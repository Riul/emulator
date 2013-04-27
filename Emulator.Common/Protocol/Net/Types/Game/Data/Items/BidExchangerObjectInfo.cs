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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects;

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items
{
    public class BidExchangerObjectInfo
    {
        public const short Id = 122;
        public ObjectEffect[] effects;

        public int objectUID;
        public bool overMax;
        public short powerRate;
        public int[] prices;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public BidExchangerObjectInfo()
        {
        }

        public BidExchangerObjectInfo(int objectUID, short powerRate, bool overMax, ObjectEffect[] effects, int[] prices)
        {
            this.objectUID = objectUID;
            this.powerRate = powerRate;
            this.overMax = overMax;
            this.effects = effects;
            this.prices = prices;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(objectUID);
            writer.WriteShort(powerRate);
            writer.WriteBoolean(overMax);
            writer.WriteUShort((ushort) effects.Length);
            foreach (var entry in effects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) prices.Length);
            foreach (var entry in prices)
            {
                writer.WriteInt(entry);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            powerRate = reader.ReadShort();
            overMax = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            effects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                effects[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                effects[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            prices = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                prices[i] = reader.ReadInt();
            }
        }
    }
}