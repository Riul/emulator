#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:45
// */
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


        public JobCrafterDirectoryEntryMessage()
        {
        }

        public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo[] jobInfoList, EntityLook playerLook)
        {
            this.playerInfo = playerInfo;
            this.jobInfoList = jobInfoList;
            this.playerLook = playerLook;
        }

        public override uint MessageId
        {
            get { return Id; }
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