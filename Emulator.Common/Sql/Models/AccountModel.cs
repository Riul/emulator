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
//     Created on 26/04/2013 at 16:52
// */
#endregion

using MySql.Data.MySqlClient;

namespace Emulator.Common.Sql.Models
{
    public class AccountModel : IModel
    {
        public const string TABLE = "accounts";
        public AccountModel() { }

        public AccountModel(MySqlDataReader reader)
        {
            InitFromData(reader);
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public bool Banned { get; set; }
        public int AdminLevel { get; set; }
        public int LastServer { get; set; }
        public CharacterModel[] Characters { get; set; }

        public void InitFromData(MySqlDataReader reader)
        {
            Id = (int)reader["id"];
            Username = (string)reader["username"];
            Password = (string)reader["password"];
            Nickname = (string)reader["nickname"];
            SecretQuestion = (string)reader["secretQuestion"];
            SecretAnswer = (string)reader["secretAnswer"];
            Banned = (bool)reader["banned"];
            AdminLevel = (int)reader["adminLevel"];
            LastServer = (int)reader["lastServer"];
        }
    }
}
