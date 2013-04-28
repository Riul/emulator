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
    public class PrismFightDefenderLeaveMessage : NetworkMessage
    {
        public const uint ID = 5892;

        public override uint MessageId
        {
            get { return ID; }
        }

        public double FightId { get; set; }
        public int FighterToRemoveId { get; set; }
        public int Successor { get; set; }


        public PrismFightDefenderLeaveMessage()
        {
        }

        public PrismFightDefenderLeaveMessage(double fightId, int fighterToRemoveId, int successor)
        {
            FightId = fightId;
            FighterToRemoveId = fighterToRemoveId;
            Successor = successor;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteInt(FighterToRemoveId);
            writer.WriteInt(Successor);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadDouble();
            FighterToRemoveId = reader.ReadInt();
            Successor = reader.ReadInt();
        }
    }
}