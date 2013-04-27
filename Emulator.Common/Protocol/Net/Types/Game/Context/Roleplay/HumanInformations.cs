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
//     Created on 26/04/2013 at 16:46
// */
#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Character.Restriction;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class HumanInformations
    {
        public const short Id = 157;
        public HumanOption[] options;

        public ActorRestrictionsInformations restrictions;
        public bool sex;


        public HumanInformations()
        {
        }

        public HumanInformations(ActorRestrictionsInformations restrictions, bool sex, HumanOption[] options)
        {
            this.restrictions = restrictions;
            this.sex = sex;
            this.options = options;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            restrictions.Serialize(writer);
            writer.WriteBoolean(sex);
            writer.WriteUShort((ushort) options.Length);
            foreach (var entry in options)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            restrictions = new ActorRestrictionsInformations();
            restrictions.Deserialize(reader);
            sex = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            options = new HumanOption[limit];
            for (int i = 0; i < limit; i++)
            {
                options[i] = Types.ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
                options[i].Deserialize(reader);
            }
        }
    }
}