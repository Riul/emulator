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
using Emulator.Common.Protocol.Net.Types.Version;

namespace Emulator.Common.Protocol.Net.Messages.Connection
{
    public class IdentificationMessage : NetworkMessage
    {
        public const uint ID = 4;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool Autoconnect { get; set; }
        public bool UseCertificate { get; set; }
        public bool UseLoginToken { get; set; }
        public VersionExtended Version { get; set; }
        public string Lang { get; set; }
        public byte[] Credentials { get; set; }
        public short ServerId { get; set; }


        public IdentificationMessage()
        {
        }

        public IdentificationMessage(bool autoconnect, bool useCertificate, bool useLoginToken, VersionExtended version, string lang, byte[] credentials, short serverId)
        {
            Autoconnect = autoconnect;
            UseCertificate = useCertificate;
            UseLoginToken = useLoginToken;
            Version = version;
            Lang = lang;
            Credentials = credentials;
            ServerId = serverId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, Autoconnect);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, UseCertificate);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, UseLoginToken);
            writer.WriteByte(flag1);
            Version.Serialize(writer);
            writer.WriteUTF(Lang);
            writer.WriteUShort((ushort) Credentials.Length);
            foreach (var entry in Credentials)
            {
                writer.WriteByte(entry);
            }
            writer.WriteShort(ServerId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            Autoconnect = BooleanByteWrapper.GetFlag(flag1, 0);
            UseCertificate = BooleanByteWrapper.GetFlag(flag1, 1);
            UseLoginToken = BooleanByteWrapper.GetFlag(flag1, 2);
            Version = new VersionExtended();
            Version.Deserialize(reader);
            Lang = reader.ReadUTF();
            var limit = reader.ReadUShort();
            Credentials = new byte[limit];
            for (int i = 0; i < limit; i++)
            {
                Credentials[i] = reader.ReadByte();
            }
            ServerId = reader.ReadShort();
        }
    }
}