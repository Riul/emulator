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
// Created on 26/04/2013 at 16:45
#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Job
{
    public class JobExperienceUpdateMessage : NetworkMessage
    {
        public const uint Id = 5654;

        public JobExperience experiencesUpdate;

        public override uint MessageId
        {
            get { return Id; }
        }


        public JobExperienceUpdateMessage()
        {
        }

        public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
        {
            this.experiencesUpdate = experiencesUpdate;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            experiencesUpdate.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            experiencesUpdate = new JobExperience();
            experiencesUpdate.Deserialize(reader);
        }
    }
}