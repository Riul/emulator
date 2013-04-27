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
    public class GameRolePlayNpcInformations : GameRolePlayActorInformations
    {
        public const short Id = 156;

        public short npcId;
        public bool sex;
        public short specialArtworkId;

        public override short TypeId
        {
            get { return Id; }
        }


        public GameRolePlayNpcInformations()
        {
        }

        public GameRolePlayNpcInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, short npcId, bool sex, short specialArtworkId)
            : base(contextualId, look, disposition)
        {
            this.npcId = npcId;
            this.sex = sex;
            this.specialArtworkId = specialArtworkId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(npcId);
            writer.WriteBoolean(sex);
            writer.WriteShort(specialArtworkId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            npcId = reader.ReadShort();
            if (npcId < 0)
                throw new Exception("Forbidden value on npcId = " + npcId + ", it doesn't respect the following condition : npcId < 0");
            sex = reader.ReadBoolean();
            specialArtworkId = reader.ReadShort();
            if (specialArtworkId < 0)
                throw new Exception("Forbidden value on specialArtworkId = " + specialArtworkId + ", it doesn't respect the following condition : specialArtworkId < 0");
        }
    }
}