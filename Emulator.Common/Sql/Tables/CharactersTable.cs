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
// Created on 26/04/2013 at 17:08
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
