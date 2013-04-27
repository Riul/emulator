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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public const short Id = 159;

        public int accountId;
        public HumanInformations humanoidInfo;

        public override short TypeId
        {
            get { return Id; }
        }


        public GameRolePlayHumanoidInformations()
        {
        }

        public GameRolePlayHumanoidInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId)
            : base(contextualId, look, disposition, name)
        {
            this.humanoidInfo = humanoidInfo;
            this.accountId = accountId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(humanoidInfo.TypeId);
            humanoidInfo.Serialize(writer);
            writer.WriteInt(accountId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            humanoidInfo = Types.ProtocolTypeManager.GetInstance<HumanInformations>(reader.ReadShort());
            humanoidInfo.Deserialize(reader);
            accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
        }
    }
}