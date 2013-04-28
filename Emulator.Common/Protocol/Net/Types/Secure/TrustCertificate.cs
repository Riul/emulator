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

namespace Emulator.Common.Protocol.Net.Types.Secure
{
    public class TrustCertificate
    {
        public const short ID = 377;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int Id { get; set; }
        public string Hash { get; set; }


        public TrustCertificate()
        {
        }

        public TrustCertificate(int id, string hash)
        {
            Id = id;
            Hash = hash;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Id);
            writer.WriteUTF(Hash);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Id = reader.ReadInt();
            Hash = reader.ReadUTF();
        }
    }
}