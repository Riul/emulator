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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryMessage : NetworkMessage
    {
        public const uint Id = 6044;

        public JobCrafterDirectoryEntryJobInfo[] jobInfoList;
        public JobCrafterDirectoryEntryPlayerInfo playerInfo;
        public EntityLook playerLook;

        public override uint MessageId
        {
            get { return Id; }
        }


        public JobCrafterDirectoryEntryMessage()
        {
        }

        public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo[] jobInfoList, EntityLook playerLook)
        {
            this.playerInfo = playerInfo;
            this.jobInfoList = jobInfoList;
            this.playerLook = playerLook;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            playerInfo.Serialize(writer);
            writer.WriteUShort((ushort) jobInfoList.Length);
            foreach (var entry in jobInfoList)
            {
                entry.Serialize(writer);
            }
            playerLook.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            playerInfo.Deserialize(reader);
            var limit = reader.ReadUShort();
            jobInfoList = new JobCrafterDirectoryEntryJobInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                jobInfoList[i] = new JobCrafterDirectoryEntryJobInfo();
                jobInfoList[i].Deserialize(reader);
            }
            playerLook = new EntityLook();
            playerLook.Deserialize(reader);
        }
    }
}