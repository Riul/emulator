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
    public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
    {
        public const short ID = 180;

        public override short TypeId
        {
            get { return ID; }
        }

        public string OwnerName { get; set; }
        public byte Level { get; set; }


        public GameRolePlayMountInformations()
        {
        }

        public GameRolePlayMountInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, string name, string ownerName, byte level)
                : base(contextualId, look, disposition, name)
        {
            OwnerName = ownerName;
            Level = level;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(OwnerName);
            writer.WriteByte(Level);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            OwnerName = reader.ReadUTF();
            Level = reader.ReadByte();
        }
    }
}