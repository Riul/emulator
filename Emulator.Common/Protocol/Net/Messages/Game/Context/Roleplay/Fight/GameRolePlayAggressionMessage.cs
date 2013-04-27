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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Fight
{
    public class GameRolePlayAggressionMessage : NetworkMessage
    {
        public const uint Id = 6073;

        public int attackerId;
        public int defenderId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameRolePlayAggressionMessage()
        {
        }

        public GameRolePlayAggressionMessage(int attackerId, int defenderId)
        {
            this.attackerId = attackerId;
            this.defenderId = defenderId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(attackerId);
            writer.WriteInt(defenderId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            attackerId = reader.ReadInt();
            if (attackerId < 0)
                throw new Exception("Forbidden value on attackerId = " + attackerId + ", it doesn't respect the following condition : attackerId < 0");
            defenderId = reader.ReadInt();
            if (defenderId < 0)
                throw new Exception("Forbidden value on defenderId = " + defenderId + ", it doesn't respect the following condition : defenderId < 0");
        }
    }
}