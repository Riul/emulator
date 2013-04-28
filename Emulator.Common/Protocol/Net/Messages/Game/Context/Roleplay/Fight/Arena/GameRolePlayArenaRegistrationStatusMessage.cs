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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaRegistrationStatusMessage : NetworkMessage
    {
        public const uint ID = 6284;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool Registered { get; set; }
        public sbyte Step { get; set; }
        public int BattleMode { get; set; }


        public GameRolePlayArenaRegistrationStatusMessage()
        {
        }

        public GameRolePlayArenaRegistrationStatusMessage(bool registered, sbyte step, int battleMode)
        {
            Registered = registered;
            Step = step;
            BattleMode = battleMode;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(Registered);
            writer.WriteSByte(Step);
            writer.WriteInt(BattleMode);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Registered = reader.ReadBoolean();
            Step = reader.ReadSByte();
            BattleMode = reader.ReadInt();
        }
    }
}