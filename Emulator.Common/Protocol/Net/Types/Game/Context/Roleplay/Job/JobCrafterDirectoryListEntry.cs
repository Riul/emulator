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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryListEntry
    {
        public const short ID = 196;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
        public JobCrafterDirectoryEntryJobInfo JobInfo { get; set; }


        public JobCrafterDirectoryListEntry()
        {
        }

        public JobCrafterDirectoryListEntry(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo jobInfo)
        {
            PlayerInfo = playerInfo;
            JobInfo = jobInfo;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            PlayerInfo.Serialize(writer);
            JobInfo.Serialize(writer);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            PlayerInfo.Deserialize(reader);
            JobInfo = new JobCrafterDirectoryEntryJobInfo();
            JobInfo.Deserialize(reader);
        }
    }
}