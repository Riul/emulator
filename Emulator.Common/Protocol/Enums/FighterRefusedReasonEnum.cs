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
// Created on 26/04/2013 at 16:48

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