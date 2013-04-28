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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Fight
{
    public class GameRolePlayPlayerFightRequestMessage : NetworkMessage
    {
        public const uint ID = 5731;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int TargetId { get; set; }
        public short TargetCellId { get; set; }
        public bool Friendly { get; set; }


        public GameRolePlayPlayerFightRequestMessage()
        {
        }

        public GameRolePlayPlayerFightRequestMessage(int targetId, short targetCellId, bool friendly)
        {
            TargetId = targetId;
            TargetCellId = targetCellId;
            Friendly = friendly;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(TargetId);
            writer.WriteShort(TargetCellId);
            writer.WriteBoolean(Friendly);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            TargetId = reader.ReadInt();
            TargetCellId = reader.ReadShort();
            Friendly = reader.ReadBoolean();
        }
    }
}