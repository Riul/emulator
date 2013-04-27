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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class MonsterInGroupInformations : MonsterInGroupLightInformations
    {
        public const short Id = 144;

        public EntityLook look;

        public override short TypeId
        {
            get { return Id; }
        }


        public MonsterInGroupInformations()
        {
        }

        public MonsterInGroupInformations(int creatureGenericId, sbyte grade, EntityLook look)
            : base(creatureGenericId, grade)
        {
            this.look = look;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            look.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            look = new EntityLook();
            look.Deserialize(reader);
        }
    }
}