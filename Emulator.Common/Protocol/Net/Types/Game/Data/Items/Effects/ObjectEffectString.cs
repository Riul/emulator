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

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects
{
    public class ObjectEffectString : ObjectEffect
    {
        public const short Id = 74;

        public string value;

        public override short TypeId
        {
            get { return Id; }
        }


        public ObjectEffectString()
        {
        }

        public ObjectEffectString(short actionId, string value)
            : base(actionId)
        {
            this.value = value;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(value);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            value = reader.ReadUTF();
        }
    }
}