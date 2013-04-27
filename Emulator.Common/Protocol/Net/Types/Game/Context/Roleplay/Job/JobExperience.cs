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
    public class JobExperience
    {
        public const short Id = 98;

        public sbyte jobId;
        public sbyte jobLevel;
        public double jobXP;
        public double jobXpLevelFloor;
        public double jobXpNextLevelFloor;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public JobExperience()
        {
        }

        public JobExperience(sbyte jobId, sbyte jobLevel, double jobXP, double jobXpLevelFloor, double jobXpNextLevelFloor)
        {
            this.jobId = jobId;
            this.jobLevel = jobLevel;
            this.jobXP = jobXP;
            this.jobXpLevelFloor = jobXpLevelFloor;
            this.jobXpNextLevelFloor = jobXpNextLevelFloor;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(jobId);
            writer.WriteSByte(jobLevel);
            writer.WriteDouble(jobXP);
            writer.WriteDouble(jobXpLevelFloor);
            writer.WriteDouble(jobXpNextLevelFloor);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            jobLevel = reader.ReadSByte();
            if (jobLevel < 0)
                throw new Exception("Forbidden value on jobLevel = " + jobLevel + ", it doesn't respect the following condition : jobLevel < 0");
            jobXP = reader.ReadDouble();
            if (jobXP < 0)
                throw new Exception("Forbidden value on jobXP = " + jobXP + ", it doesn't respect the following condition : jobXP < 0");
            jobXpLevelFloor = reader.ReadDouble();
            if (jobXpLevelFloor < 0)
                throw new Exception("Forbidden value on jobXpLevelFloor = " + jobXpLevelFloor + ", it doesn't respect the following condition : jobXpLevelFloor < 0");
            jobXpNextLevelFloor = reader.ReadDouble();
            if (jobXpNextLevelFloor < 0)
                throw new Exception("Forbidden value on jobXpNextLevelFloor = " + jobXpNextLevelFloor + ", it doesn't respect the following condition : jobXpNextLevelFloor < 0");
        }
    }
}