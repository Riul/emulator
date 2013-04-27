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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Stats
{
    public class CharacterExperienceGainMessage : NetworkMessage
    {
        public const uint Id = 6321;

        public double experienceCharacter;
        public double experienceGuild;
        public double experienceIncarnation;
        public double experienceMount;


        public CharacterExperienceGainMessage()
        {
        }

        public CharacterExperienceGainMessage(double experienceCharacter, double experienceMount, double experienceGuild, double experienceIncarnation)
        {
            this.experienceCharacter = experienceCharacter;
            this.experienceMount = experienceMount;
            this.experienceGuild = experienceGuild;
            this.experienceIncarnation = experienceIncarnation;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(experienceCharacter);
            writer.WriteDouble(experienceMount);
            writer.WriteDouble(experienceGuild);
            writer.WriteDouble(experienceIncarnation);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            experienceCharacter = reader.ReadDouble();
            if (experienceCharacter < 0)
                throw new Exception("Forbidden value on experienceCharacter = " + experienceCharacter + ", it doesn't respect the following condition : experienceCharacter < 0");
            experienceMount = reader.ReadDouble();
            if (experienceMount < 0)
                throw new Exception("Forbidden value on experienceMount = " + experienceMount + ", it doesn't respect the following condition : experienceMount < 0");
            experienceGuild = reader.ReadDouble();
            if (experienceGuild < 0)
                throw new Exception("Forbidden value on experienceGuild = " + experienceGuild + ", it doesn't respect the following condition : experienceGuild < 0");
            experienceIncarnation = reader.ReadDouble();
            if (experienceIncarnation < 0)
                throw new Exception("Forbidden value on experienceIncarnation = " + experienceIncarnation + ", it doesn't respect the following condition : experienceIncarnation < 0");
        }
    }
}