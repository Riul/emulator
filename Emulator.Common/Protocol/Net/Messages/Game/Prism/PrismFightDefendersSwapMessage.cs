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

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismFightDefendersSwapMessage : NetworkMessage
    {
        public const uint ID = 5902;

        public override uint MessageId
        {
            get { return ID; }
        }

        public double FightId { get; set; }
        public int FighterId1 { get; set; }
        public int FighterId2 { get; set; }


        public PrismFightDefendersSwapMessage()
        {
        }

        public PrismFightDefendersSwapMessage(double fightId, int fighterId1, int fighterId2)
        {
            FightId = fightId;
            FighterId1 = fighterId1;
            FighterId2 = fighterId2;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteInt(FighterId1);
            writer.WriteInt(FighterId2);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadDouble();
            FighterId1 = reader.ReadInt();
            FighterId2 = reader.ReadInt();
        }
    }
}