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
    public class ObjectEffectDate : ObjectEffect
    {
        public const short ID = 72;

        public override short TypeId
        {
            get { return ID; }
        }

        public short Year { get; set; }
        public short Month { get; set; }
        public short Day { get; set; }
        public short Hour { get; set; }
        public short Minute { get; set; }


        public ObjectEffectDate()
        {
        }

        public ObjectEffectDate(short actionId, short year, short month, short day, short hour, short minute)
                : base(actionId)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Year);
            writer.WriteShort(Month);
            writer.WriteShort(Day);
            writer.WriteShort(Hour);
            writer.WriteShort(Minute);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Year = reader.ReadShort();
            Month = reader.ReadShort();
            Day = reader.ReadShort();
            Hour = reader.ReadShort();
            Minute = reader.ReadShort();
        }
    }
}