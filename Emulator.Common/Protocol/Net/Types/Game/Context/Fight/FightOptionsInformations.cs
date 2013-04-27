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
// Created on 26/04/2013 at 16:46
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightOptionsInformations
    {
        public const short Id = 20;

        public bool isAskingForHelp;
        public bool isClosed;
        public bool isRestrictedToPartyOnly;
        public bool isSecret;


        public FightOptionsInformations()
        {
        }

        public FightOptionsInformations(bool isSecret, bool isRestrictedToPartyOnly, bool isClosed, bool isAskingForHelp)
        {
            this.isSecret = isSecret;
            this.isRestrictedToPartyOnly = isRestrictedToPartyOnly;
            this.isClosed = isClosed;
            this.isAskingForHelp = isAskingForHelp;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isSecret);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isRestrictedToPartyOnly);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, isClosed);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, isAskingForHelp);
            writer.WriteByte(flag1);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            isSecret = BooleanByteWrapper.GetFlag(flag1, 0);
            isRestrictedToPartyOnly = BooleanByteWrapper.GetFlag(flag1, 1);
            isClosed = BooleanByteWrapper.GetFlag(flag1, 2);
            isAskingForHelp = BooleanByteWrapper.GetFlag(flag1, 3);
        }
    }
}