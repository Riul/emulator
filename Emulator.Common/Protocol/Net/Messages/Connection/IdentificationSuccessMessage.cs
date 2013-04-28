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

namespace Emulator.Common.Protocol.Net.Messages.Connection
{
    public class IdentificationSuccessMessage : NetworkMessage
    {
        public const uint ID = 22;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool HasRights { get; set; }
        public bool WasAlreadyConnected { get; set; }
        public string Login { get; set; }
        public string Nickname { get; set; }
        public int AccountId { get; set; }
        public sbyte CommunityId { get; set; }
        public string SecretQuestion { get; set; }
        public double SubscriptionEndDate { get; set; }
        public double AccountCreation { get; set; }


        public IdentificationSuccessMessage()
        {
        }

        public IdentificationSuccessMessage(bool hasRights, bool wasAlreadyConnected, string login, string nickname, int accountId, sbyte communityId, string secretQuestion, double subscriptionEndDate, double accountCreation)
        {
            HasRights = hasRights;
            WasAlreadyConnected = wasAlreadyConnected;
            Login = login;
            Nickname = nickname;
            AccountId = accountId;
            CommunityId = communityId;
            SecretQuestion = secretQuestion;
            SubscriptionEndDate = subscriptionEndDate;
            AccountCreation = accountCreation;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, HasRights);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, WasAlreadyConnected);
            writer.WriteByte(flag1);
            writer.WriteUTF(Login);
            writer.WriteUTF(Nickname);
            writer.WriteInt(AccountId);
            writer.WriteSByte(CommunityId);
            writer.WriteUTF(SecretQuestion);
            writer.WriteDouble(SubscriptionEndDate);
            writer.WriteDouble(AccountCreation);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            HasRights = BooleanByteWrapper.GetFlag(flag1, 0);
            WasAlreadyConnected = BooleanByteWrapper.GetFlag(flag1, 1);
            Login = reader.ReadUTF();
            Nickname = reader.ReadUTF();
            AccountId = reader.ReadInt();
            CommunityId = reader.ReadSByte();
            SecretQuestion = reader.ReadUTF();
            SubscriptionEndDate = reader.ReadDouble();
            AccountCreation = reader.ReadDouble();
        }
    }
}