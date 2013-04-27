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
//     Created on 26/04/2013 at 16:48
// */
#endregion
namespace Emulator.Common.Protocol.Enums
{
    public enum FighterRefusedReasonEnum
    {
        FIGHTER_ACCEPTED = 0,
        CHALLENGE_FULL = 1,
        TEAM_FULL = 2,
        WRONG_ALIGNMENT = 3,
        WRONG_GUILD = 4,
        TOO_LATE = 5,
        MUTANT_REFUSED = 6,
        WRONG_MAP = 7,
        JUST_RESPAWNED = 8,
        IM_OCCUPIED = 9,
        OPPONENT_OCCUPIED = 10,
        FIGHT_MYSELF = 11,
        INSUFFICIENT_RIGHTS = 12,
        MEMBER_ACCOUNT_NEEDED = 13,
        OPPONENT_NOT_MEMBER = 14,
        TEAM_LIMITED_BY_MAINCHARACTER = 15,
        MULTIACCOUNT_NOT_ALLOWED = 16,
        GHOST_REFUSED = 17,
        NEED_DISHONOR = 18,
        RESTRICTED_ACCOUNT = 19,
    }
}