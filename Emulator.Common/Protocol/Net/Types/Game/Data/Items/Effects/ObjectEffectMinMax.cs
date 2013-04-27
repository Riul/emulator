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

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects
{
    public class ObjectEffectMinMax : ObjectEffect
    {
        public const short Id = 82;

        public short max;
        public short min;

        public override short TypeId
        {
            get { return Id; }
        }


        public ObjectEffectMinMax()
        {
        }

        public ObjectEffectMinMax(short actionId, short min, short max)
            : base(actionId)
        {
            this.min = min;
            this.max = max;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(min);
            writer.WriteShort(max);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            min = reader.ReadShort();
            if (min < 0)
                throw new Exception("Forbidden value on min = " + min + ", it doesn't respect the following condition : min < 0");
            max = reader.ReadShort();
            if (max < 0)
                throw new Exception("Forbidden value on max = " + max + ", it doesn't respect the following condition : max < 0");
        }
    }
}