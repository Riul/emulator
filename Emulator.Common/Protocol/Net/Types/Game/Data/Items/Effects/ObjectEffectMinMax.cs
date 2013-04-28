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

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects
{
    public class ObjectEffectMinMax : ObjectEffect
    {
        public const short ID = 82;

        public override short TypeId
        {
            get { return ID; }
        }

        public short Min { get; set; }
        public short Max { get; set; }


        public ObjectEffectMinMax()
        {
        }

        public ObjectEffectMinMax(short actionId, short min, short max)
                : base(actionId)
        {
            Min = min;
            Max = max;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Min);
            writer.WriteShort(Max);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Min = reader.ReadShort();
            Max = reader.ReadShort();
        }
    }
}