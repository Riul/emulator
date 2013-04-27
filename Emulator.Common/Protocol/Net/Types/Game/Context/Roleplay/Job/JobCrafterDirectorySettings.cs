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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectorySettings
    {
        public const short Id = 97;

        public sbyte jobId;
        public sbyte minSlot;
        public sbyte userDefinedParams;


        public JobCrafterDirectorySettings()
        {
        }

        public JobCrafterDirectorySettings(sbyte jobId, sbyte minSlot, sbyte userDefinedParams)
        {
            this.jobId = jobId;
            this.minSlot = minSlot;
            this.userDefinedParams = userDefinedParams;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(jobId);
            writer.WriteSByte(minSlot);
            writer.WriteSByte(userDefinedParams);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            minSlot = reader.ReadSByte();
            if (minSlot < 0 || minSlot > 9)
                throw new Exception("Forbidden value on minSlot = " + minSlot + ", it doesn't respect the following condition : minSlot < 0 || minSlot > 9");
            userDefinedParams = reader.ReadSByte();
            if (userDefinedParams < 0)
                throw new Exception("Forbidden value on userDefinedParams = " + userDefinedParams + ", it doesn't respect the following condition : userDefinedParams < 0");
        }
    }
}