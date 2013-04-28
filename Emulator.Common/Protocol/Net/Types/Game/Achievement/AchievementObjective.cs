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

namespace Emulator.Common.Protocol.Net.Types.Game.Achievement
{
    public class AchievementObjective
    {
        public const short ID = 404;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int Id { get; set; }
        public short MaxValue { get; set; }


        public AchievementObjective()
        {
        }

        public AchievementObjective(int id, short maxValue)
        {
            Id = id;
            MaxValue = maxValue;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Id);
            writer.WriteShort(MaxValue);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Id = reader.ReadInt();
            MaxValue = reader.ReadShort();
        }
    }
}