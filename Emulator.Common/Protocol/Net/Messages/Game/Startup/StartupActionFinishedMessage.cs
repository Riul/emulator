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

namespace Emulator.Common.Protocol.Net.Messages.Game.Startup
{
    public class StartupActionFinishedMessage : NetworkMessage
    {
        public const uint ID = 1304;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool Success { get; set; }
        public bool AutomaticAction { get; set; }
        public int ActionId { get; set; }


        public StartupActionFinishedMessage()
        {
        }

        public StartupActionFinishedMessage(bool success, bool automaticAction, int actionId)
        {
            Success = success;
            AutomaticAction = automaticAction;
            ActionId = actionId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, Success);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, AutomaticAction);
            writer.WriteByte(flag1);
            writer.WriteInt(ActionId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(flag1, 0);
            AutomaticAction = BooleanByteWrapper.GetFlag(flag1, 1);
            ActionId = reader.ReadInt();
        }
    }
}