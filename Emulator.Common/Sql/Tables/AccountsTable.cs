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
//     Created on 26/04/2013 at 16:54
// */
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
