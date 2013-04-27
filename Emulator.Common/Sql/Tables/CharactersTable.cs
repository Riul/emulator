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
//     Created on 26/04/2013 at 17:08
// */
#endregion

using System.Collections.Generic;
using Emulator.Common.Sql.Models;
using MySql.Data.MySqlClient;

namespace Emulator.Common.Sql.Tables
{
    public class CharactersTable
    {
        public static CharacterModel Load(int id)
        {
            lock (SQLManager.Locker)
            {
                CharacterModel result = null;
                MySqlDataReader reader = SQLManager.ExecuteQuery("SELECT * FROM {0} WHERE id='{1}'", CharacterModel.TABLE, id);

                if (reader.Read())
                {
                    result = new CharacterModel(reader);
                }
                reader.Close();

                return result;
            }
        }

        public static CharacterModel Load(string name)
        {
            lock (SQLManager.Locker)
            {
                CharacterModel result = null;
                MySqlDataReader reader = SQLManager.ExecuteQuery("SELECT * FROM {0} WHERE name='{1}'", CharacterModel.TABLE, name);

                if (reader.Read())
                {
                    result = new CharacterModel(reader);
                }
                reader.Close();

                return result;
            }
        }

        public static CharacterModel[] LoadFromAccount(int accountId)
        {
            lock (SQLManager.Locker)
            {
                List<CharacterModel> result = new List<CharacterModel>();
                MySqlDataReader reader = SQLManager.ExecuteQuery("SELECT * FROM {0} WHERE accountId='{1}'", CharacterModel.TABLE, accountId);

                while (reader.Read())
                {
                    result.Add(new CharacterModel(reader));
                }
                reader.Close();

                return result.ToArray();
            }
        }
    }
}
