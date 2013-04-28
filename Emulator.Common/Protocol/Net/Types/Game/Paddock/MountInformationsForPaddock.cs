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

namespace Emulator.Common.Protocol.Net.Types.Game.Paddock
{
    public class MountInformationsForPaddock
    {
        public const short ID = 184;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int ModelId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }


        public MountInformationsForPaddock()
        {
        }

        public MountInformationsForPaddock(int modelId, string name, string ownerName)
        {
            ModelId = modelId;
            Name = name;
            OwnerName = ownerName;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(ModelId);
            writer.WriteUTF(Name);
            writer.WriteUTF(OwnerName);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            ModelId = reader.ReadInt();
            Name = reader.ReadUTF();
            OwnerName = reader.ReadUTF();
        }
    }
}