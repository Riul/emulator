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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildInformationsGeneralMessage : NetworkMessage
    {
        public const uint ID = 5557;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool Enabled { get; set; }
        public bool AbandonnedPaddock { get; set; }
        public byte Level { get; set; }
        public double ExpLevelFloor { get; set; }
        public double Experience { get; set; }
        public double ExpNextLevelFloor { get; set; }
        public int CreationDate { get; set; }


        public GuildInformationsGeneralMessage()
        {
        }

        public GuildInformationsGeneralMessage(bool enabled, bool abandonnedPaddock, byte level, double expLevelFloor, double experience, double expNextLevelFloor, int creationDate)
        {
            Enabled = enabled;
            AbandonnedPaddock = abandonnedPaddock;
            Level = level;
            ExpLevelFloor = expLevelFloor;
            Experience = experience;
            ExpNextLevelFloor = expNextLevelFloor;
            CreationDate = creationDate;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, Enabled);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, AbandonnedPaddock);
            writer.WriteByte(flag1);
            writer.WriteByte(Level);
            writer.WriteDouble(ExpLevelFloor);
            writer.WriteDouble(Experience);
            writer.WriteDouble(ExpNextLevelFloor);
            writer.WriteInt(CreationDate);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            Enabled = BooleanByteWrapper.GetFlag(flag1, 0);
            AbandonnedPaddock = BooleanByteWrapper.GetFlag(flag1, 1);
            Level = reader.ReadByte();
            ExpLevelFloor = reader.ReadDouble();
            Experience = reader.ReadDouble();
            ExpNextLevelFloor = reader.ReadDouble();
            CreationDate = reader.ReadInt();
        }
    }
}