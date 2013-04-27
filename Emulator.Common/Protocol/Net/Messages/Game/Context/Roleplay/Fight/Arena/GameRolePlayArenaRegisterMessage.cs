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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaRegisterMessage : NetworkMessage
    {
        public const uint Id = 6280;

        public int battleMode;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameRolePlayArenaRegisterMessage()
        {
        }

        public GameRolePlayArenaRegisterMessage(int battleMode)
        {
            this.battleMode = battleMode;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(battleMode);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            battleMode = reader.ReadInt();
            if (battleMode < 0)
                throw new Exception("Forbidden value on battleMode = " + battleMode + ", it doesn't respect the following condition : battleMode < 0");
        }
    }
}