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
    public class ObjectEffectLadder : ObjectEffectCreature
    {
        public const short ID = 81;

        public override short TypeId
        {
            get { return ID; }
        }

        public int MonsterCount { get; set; }


        public ObjectEffectLadder()
        {
        }

        public ObjectEffectLadder(short actionId, short monsterFamilyId, int monsterCount)
                : base(actionId, monsterFamilyId)
        {
            MonsterCount = monsterCount;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(MonsterCount);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            MonsterCount = reader.ReadInt();
        }
    }
}