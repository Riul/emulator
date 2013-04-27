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
// Created on 26/04/2013 at 16:45
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismFightDefendersSwapMessage : NetworkMessage
    {
        public const uint Id = 5902;

        public double fightId;
        public int fighterId1;
        public int fighterId2;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PrismFightDefendersSwapMessage()
        {
        }

        public PrismFightDefendersSwapMessage(double fightId, int fighterId1, int fighterId2)
        {
            this.fightId = fightId;
            this.fighterId1 = fighterId1;
            this.fighterId2 = fighterId2;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteInt(fighterId1);
            writer.WriteInt(fighterId2);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadDouble();
            fighterId1 = reader.ReadInt();
            if (fighterId1 < 0)
                throw new Exception("Forbidden value on fighterId1 = " + fighterId1 + ", it doesn't respect the following condition : fighterId1 < 0");
            fighterId2 = reader.ReadInt();
            if (fighterId2 < 0)
                throw new Exception("Forbidden value on fighterId2 = " + fighterId2 + ", it doesn't respect the following condition : fighterId2 < 0");
        }
    }
}