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
    public class ObjectEffectDuration : ObjectEffect
    {
        public const short ID = 75;

        public override short TypeId
        {
            get { return ID; }
        }

        public short Days { get; set; }
        public short Hours { get; set; }
        public short Minutes { get; set; }


        public ObjectEffectDuration()
        {
        }

        public ObjectEffectDuration(short actionId, short days, short hours, short minutes)
                : base(actionId)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Days);
            writer.WriteShort(Hours);
            writer.WriteShort(Minutes);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Days = reader.ReadShort();
            Hours = reader.ReadShort();
            Minutes = reader.ReadShort();
        }
    }
}