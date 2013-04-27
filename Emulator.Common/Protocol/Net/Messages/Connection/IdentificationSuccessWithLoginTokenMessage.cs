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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Connection
{
    public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
    {
        public const uint Id = 6209;

        public string loginToken;

        public override uint MessageId
        {
            get { return Id; }
        }


        public IdentificationSuccessWithLoginTokenMessage()
        {
        }

        public IdentificationSuccessWithLoginTokenMessage(bool hasRights, bool wasAlreadyConnected, string login, string nickname, int accountId, sbyte communityId, string secretQuestion, double subscriptionEndDate, double accountCreation, string loginToken)
            : base(hasRights, wasAlreadyConnected, login, nickname, accountId, communityId, secretQuestion, subscriptionEndDate, accountCreation)
        {
            this.loginToken = loginToken;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(loginToken);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            loginToken = reader.ReadUTF();
        }
    }
}