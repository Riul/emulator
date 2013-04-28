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

namespace Emulator.Common.Protocol.Net.Types.Game.Fight
{
    public class ProtectedEntityWaitingForHelpInfo
    {
        public const short ID = 186;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int TimeLeftBeforeFight { get; set; }
        public int WaitTimeForPlacement { get; set; }
        public sbyte NbPositionForDefensors { get; set; }


        public ProtectedEntityWaitingForHelpInfo()
        {
        }

        public ProtectedEntityWaitingForHelpInfo(int timeLeftBeforeFight, int waitTimeForPlacement, sbyte nbPositionForDefensors)
        {
            TimeLeftBeforeFight = timeLeftBeforeFight;
            WaitTimeForPlacement = waitTimeForPlacement;
            NbPositionForDefensors = nbPositionForDefensors;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(TimeLeftBeforeFight);
            writer.WriteInt(WaitTimeForPlacement);
            writer.WriteSByte(NbPositionForDefensors);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            TimeLeftBeforeFight = reader.ReadInt();
            WaitTimeForPlacement = reader.ReadInt();
            NbPositionForDefensors = reader.ReadSByte();
        }
    }
}