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

namespace Emulator.Common.Protocol.Net.Types.Game.Paddock
{
    public class MountInformationsForPaddock
    {
        public const short Id = 184;

        public int modelId;
        public string name;
        public string ownerName;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public MountInformationsForPaddock()
        {
        }

        public MountInformationsForPaddock(int modelId, string name, string ownerName)
        {
            this.modelId = modelId;
            this.name = name;
            this.ownerName = ownerName;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(modelId);
            writer.WriteUTF(name);
            writer.WriteUTF(ownerName);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            modelId = reader.ReadInt();
            name = reader.ReadUTF();
            ownerName = reader.ReadUTF();
        }
    }
}