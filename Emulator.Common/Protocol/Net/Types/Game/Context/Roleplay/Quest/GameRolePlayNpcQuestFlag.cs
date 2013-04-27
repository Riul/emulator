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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Quest
{
    public class GameRolePlayNpcQuestFlag
    {
        public const short Id = 384;

        public short[] questsToStartId;
        public short[] questsToValidId;


        public GameRolePlayNpcQuestFlag()
        {
        }

        public GameRolePlayNpcQuestFlag(short[] questsToValidId, short[] questsToStartId)
        {
            this.questsToValidId = questsToValidId;
            this.questsToStartId = questsToStartId;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) questsToValidId.Length);
            foreach (var entry in questsToValidId)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) questsToStartId.Length);
            foreach (var entry in questsToStartId)
            {
                writer.WriteShort(entry);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            questsToValidId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                questsToValidId[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            questsToStartId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                questsToStartId[i] = reader.ReadShort();
            }
        }
    }
}