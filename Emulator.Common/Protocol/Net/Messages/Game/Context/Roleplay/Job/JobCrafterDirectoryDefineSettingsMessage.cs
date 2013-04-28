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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryDefineSettingsMessage : NetworkMessage
    {
        public const uint ID = 5649;

        public override uint MessageId
        {
            get { return ID; }
        }

        public JobCrafterDirectorySettings Settings { get; set; }


        public JobCrafterDirectoryDefineSettingsMessage()
        {
        }

        public JobCrafterDirectoryDefineSettingsMessage(JobCrafterDirectorySettings settings)
        {
            Settings = settings;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            Settings.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Settings = new JobCrafterDirectorySettings();
            Settings.Deserialize(reader);
        }
    }
}