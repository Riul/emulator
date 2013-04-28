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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class GameRolePlayNpcInformations : GameRolePlayActorInformations
    {
        public const short ID = 156;

        public override short TypeId
        {
            get { return ID; }
        }

        public short NpcId { get; set; }
        public bool Sex { get; set; }
        public short SpecialArtworkId { get; set; }


        public GameRolePlayNpcInformations()
        {
        }

        public GameRolePlayNpcInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, short npcId, bool sex, short specialArtworkId)
                : base(contextualId, look, disposition)
        {
            NpcId = npcId;
            Sex = sex;
            SpecialArtworkId = specialArtworkId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(NpcId);
            writer.WriteBoolean(Sex);
            writer.WriteShort(SpecialArtworkId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadShort();
            Sex = reader.ReadBoolean();
            SpecialArtworkId = reader.ReadShort();
        }
    }
}