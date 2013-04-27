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
    public class ObjectItemToSellInBid : ObjectItemToSell
    {
        public const short Id = 164;

        public short unsoldDelay;

        public override short TypeId
        {
            get { return Id; }
        }


        public ObjectItemToSellInBid()
        {
        }

        public ObjectItemToSellInBid(short objectGID, short powerRate, bool overMax, ObjectEffect[] effects, int objectUID, int quantity, int objectPrice, short unsoldDelay)
            : base(objectGID, powerRate, overMax, effects, objectUID, quantity, objectPrice)
        {
            this.unsoldDelay = unsoldDelay;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(unsoldDelay);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            unsoldDelay = reader.ReadShort();
            if (unsoldDelay < 0)
                throw new Exception("Forbidden value on unsoldDelay = " + unsoldDelay + ", it doesn't respect the following condition : unsoldDelay < 0");
        }
    }
}