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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Job
{
    public class JobExperienceUpdateMessage : NetworkMessage
    {
        public const uint Id = 5654;

        public JobExperience experiencesUpdate;


        public JobExperienceUpdateMessage()
        {
        }

        public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
        {
            this.experiencesUpdate = experiencesUpdate;
        }

        public override uint MessageId
        {
            get { return Id; }
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