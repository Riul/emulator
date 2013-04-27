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
    public class ObjectEffectDuration : ObjectEffect
    {
        public const short Id = 75;

        public short days;
        public short hours;
        public short minutes;

        public override short TypeId
        {
            get { return Id; }
        }


        public ObjectEffectDuration()
        {
        }

        public ObjectEffectDuration(short actionId, short days, short hours, short minutes)
            : base(actionId)
        {
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(days);
            writer.WriteShort(hours);
            writer.WriteShort(minutes);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            days = reader.ReadShort();
            if (days < 0)
                throw new Exception("Forbidden value on days = " + days + ", it doesn't respect the following condition : days < 0");
            hours = reader.ReadShort();
            if (hours < 0)
                throw new Exception("Forbidden value on hours = " + hours + ", it doesn't respect the following condition : hours < 0");
            minutes = reader.ReadShort();
            if (minutes < 0)
                throw new Exception("Forbidden value on minutes = " + minutes + ", it doesn't respect the following condition : minutes < 0");
        }
    }
}