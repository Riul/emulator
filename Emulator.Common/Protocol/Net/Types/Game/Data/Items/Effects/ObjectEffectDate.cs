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
    public class ObjectEffectDate : ObjectEffect
    {
        public const short Id = 72;

        public short day;
        public short hour;
        public short minute;
        public short month;
        public short year;

        public override short TypeId
        {
            get { return Id; }
        }


        public ObjectEffectDate()
        {
        }

        public ObjectEffectDate(short actionId, short year, short month, short day, short hour, short minute)
            : base(actionId)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(year);
            writer.WriteShort(month);
            writer.WriteShort(day);
            writer.WriteShort(hour);
            writer.WriteShort(minute);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            year = reader.ReadShort();
            if (year < 0)
                throw new Exception("Forbidden value on year = " + year + ", it doesn't respect the following condition : year < 0");
            month = reader.ReadShort();
            if (month < 0)
                throw new Exception("Forbidden value on month = " + month + ", it doesn't respect the following condition : month < 0");
            day = reader.ReadShort();
            if (day < 0)
                throw new Exception("Forbidden value on day = " + day + ", it doesn't respect the following condition : day < 0");
            hour = reader.ReadShort();
            if (hour < 0)
                throw new Exception("Forbidden value on hour = " + hour + ", it doesn't respect the following condition : hour < 0");
            minute = reader.ReadShort();
            if (minute < 0)
                throw new Exception("Forbidden value on minute = " + minute + ", it doesn't respect the following condition : minute < 0");
        }
    }
}