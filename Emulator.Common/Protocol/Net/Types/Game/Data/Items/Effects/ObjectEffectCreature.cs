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

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects
{
    public class ObjectEffectCreature : ObjectEffect
    {
        public const short ID = 71;

        public override short TypeId
        {
            get { return ID; }
        }

        public short MonsterFamilyId { get; set; }


        public ObjectEffectCreature()
        {
        }

        public ObjectEffectCreature(short actionId, short monsterFamilyId)
                : base(actionId)
        {
            MonsterFamilyId = monsterFamilyId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MonsterFamilyId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            MonsterFamilyId = reader.ReadShort();
        }
    }
}