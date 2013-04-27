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

namespace Emulator.Common.Protocol.Net.Types.Game.Fight
{
    public class ProtectedEntityWaitingForHelpInfo
    {
        public const short Id = 186;
        public sbyte nbPositionForDefensors;

        public int timeLeftBeforeFight;
        public int waitTimeForPlacement;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public ProtectedEntityWaitingForHelpInfo()
        {
        }

        public ProtectedEntityWaitingForHelpInfo(int timeLeftBeforeFight, int waitTimeForPlacement, sbyte nbPositionForDefensors)
        {
            this.timeLeftBeforeFight = timeLeftBeforeFight;
            this.waitTimeForPlacement = waitTimeForPlacement;
            this.nbPositionForDefensors = nbPositionForDefensors;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(timeLeftBeforeFight);
            writer.WriteInt(waitTimeForPlacement);
            writer.WriteSByte(nbPositionForDefensors);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            timeLeftBeforeFight = reader.ReadInt();
            waitTimeForPlacement = reader.ReadInt();
            nbPositionForDefensors = reader.ReadSByte();
            if (nbPositionForDefensors < 0)
                throw new Exception("Forbidden value on nbPositionForDefensors = " + nbPositionForDefensors + ", it doesn't respect the following condition : nbPositionForDefensors < 0");
        }
    }
}