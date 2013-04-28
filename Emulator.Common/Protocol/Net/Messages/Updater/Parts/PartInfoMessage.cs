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
using Emulator.Common.Protocol.Net.Types.Updater;

namespace Emulator.Common.Protocol.Net.Messages.Updater.Parts
{
    public class PartInfoMessage : NetworkMessage
    {
        public const uint ID = 1508;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ContentPart Part { get; set; }
        public float InstallationPercent { get; set; }


        public PartInfoMessage()
        {
        }

        public PartInfoMessage(ContentPart part, float installationPercent)
        {
            Part = part;
            InstallationPercent = installationPercent;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            Part.Serialize(writer);
            writer.WriteFloat(InstallationPercent);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Part = new ContentPart();
            Part.Deserialize(reader);
            InstallationPercent = reader.ReadFloat();
        }
    }
}