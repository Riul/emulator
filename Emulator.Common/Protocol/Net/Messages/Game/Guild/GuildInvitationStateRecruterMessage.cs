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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildInvitationStateRecruterMessage : NetworkMessage
    {
        public const uint ID = 5563;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string RecrutedName { get; set; }
        public sbyte InvitationState { get; set; }


        public GuildInvitationStateRecruterMessage()
        {
        }

        public GuildInvitationStateRecruterMessage(string recrutedName, sbyte invitationState)
        {
            RecrutedName = recrutedName;
            InvitationState = invitationState;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(RecrutedName);
            writer.WriteSByte(InvitationState);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            RecrutedName = reader.ReadUTF();
            InvitationState = reader.ReadSByte();
        }
    }
}