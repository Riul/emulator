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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryMessage : NetworkMessage
    {
        public const uint ID = 6044;

        public override uint MessageId
        {
            get { return ID; }
        }

        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
        public JobCrafterDirectoryEntryJobInfo[] JobInfoList { get; set; }
        public EntityLook PlayerLook { get; set; }


        public JobCrafterDirectoryEntryMessage()
        {
        }

        public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo[] jobInfoList, EntityLook playerLook)
        {
            PlayerInfo = playerInfo;
            JobInfoList = jobInfoList;
            PlayerLook = playerLook;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            PlayerInfo.Serialize(writer);
            writer.WriteUShort((ushort) JobInfoList.Length);
            foreach (var entry in JobInfoList)
            {
                entry.Serialize(writer);
            }
            PlayerLook.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            PlayerInfo.Deserialize(reader);
            var limit = reader.ReadUShort();
            JobInfoList = new JobCrafterDirectoryEntryJobInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                JobInfoList[i] = new JobCrafterDirectoryEntryJobInfo();
                JobInfoList[i].Deserialize(reader);
            }
            PlayerLook = new EntityLook();
            PlayerLook.Deserialize(reader);
        }
    }
}