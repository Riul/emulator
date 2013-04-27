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
// Created on 26/04/2013 at 16:52
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
