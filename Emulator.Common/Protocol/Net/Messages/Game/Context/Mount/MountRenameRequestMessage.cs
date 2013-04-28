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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Mount
{
    public class MountRenameRequestMessage : NetworkMessage
    {
        public const uint ID = 5987;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string Name { get; set; }
        public double MountId { get; set; }


        public MountRenameRequestMessage()
        {
        }

        public MountRenameRequestMessage(string name, double mountId)
        {
            Name = name;
            MountId = mountId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteDouble(MountId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Name = reader.ReadUTF();
            MountId = reader.ReadDouble();
        }
    }
}