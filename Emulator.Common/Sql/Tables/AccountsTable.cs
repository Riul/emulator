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
// Created on 26/04/2013 at 16:54
#endregion

using Emulator.Common.Sql.Models;
using MySql.Data.MySqlClient;

namespace Emulator.Common.Sql.Tables
{
    public class AccountsTable
    {
        public static AccountModel Load(string username)
        {
            lock (SQLManager.Locker)
            {
                AccountModel account = null;
                MySqlDataReader reader = SQLManager.ExecuteQuery("SELECT * FROM {0} WHERE username='{1}'", AccountModel.TABLE, username);

                if (reader.Read())
                {
                    account = new AccountModel(reader);
                }
                reader.Close();

                if (account != null)
                {
                    account.Characters = CharactersTable.LoadFromAccount(account.Id);
                }
                return account;
            }
        }

        public static AccountModel Load(int accountId)
        {
            lock (SQLManager.Locker)
            {
                AccountModel account = null;
                MySqlDataReader reader = SQLManager.ExecuteQuery("SELECT * FROM {0} WHERE id='{1}'", AccountModel.TABLE, accountId);

                if (reader.Read())
                {
                    account = new AccountModel(reader);
                }
                reader.Close();
                return account;
            }
        }
    }
}
