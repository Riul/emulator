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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context
{
    public class GameContextActorInformations
    {
        public const short ID = 150;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int ContextualId { get; set; }
        public EntityLook Look { get; set; }
        public EntityDispositionInformations Disposition { get; set; }


        public GameContextActorInformations()
        {
        }

        public GameContextActorInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(ContextualId);
            Look.Serialize(writer);
            writer.WriteShort(Disposition.TypeId);
            Disposition.Serialize(writer);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            ContextualId = reader.ReadInt();
            Look = new EntityLook();
            Look.Deserialize(reader);
            Disposition = Types.ProtocolTypeManager.GetInstance<EntityDispositionInformations>(reader.ReadShort());
            Disposition.Deserialize(reader);
        }
    }
}