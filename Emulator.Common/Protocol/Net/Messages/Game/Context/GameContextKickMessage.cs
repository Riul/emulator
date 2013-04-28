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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context
{
    public class GameContextKickMessage : NetworkMessage
    {
        public const uint ID = 6081;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int TargetId { get; set; }


        public GameContextKickMessage()
        {
        }

        public GameContextKickMessage(int targetId)
        {
            TargetId = targetId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(TargetId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            TargetId = reader.ReadInt();
        }
    }
}