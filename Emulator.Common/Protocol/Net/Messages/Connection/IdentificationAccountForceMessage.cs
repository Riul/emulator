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
    public class IdentificationAccountForceMessage : IdentificationMessage
    {
        public const uint ID = 6119;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string ForcedAccountLogin { get; set; }


        public IdentificationAccountForceMessage()
        {
        }

        public IdentificationAccountForceMessage(bool autoconnect, bool useCertificate, bool useLoginToken, VersionExtended version, string lang, byte[] credentials, short serverId, string forcedAccountLogin)
                : base(autoconnect, useCertificate, useLoginToken, version, lang, credentials, serverId)
        {
            ForcedAccountLogin = forcedAccountLogin;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(ForcedAccountLogin);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            ForcedAccountLogin = reader.ReadUTF();
        }
    }
}