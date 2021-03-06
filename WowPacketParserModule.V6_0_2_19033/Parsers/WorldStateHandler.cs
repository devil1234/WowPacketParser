using System;
using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Parsing;
using CoreParsers = WowPacketParser.Parsing.Parsers;

namespace WowPacketParserModule.V6_0_2_19033.Parsers
{
    public static class WorldStateHandler
    {
        [Parser(Opcode.SMSG_INIT_WORLD_STATES)]
        public static void HandleInitWorldStates(Packet packet)
        {
            packet.ReadEntry<Int32>(StoreNameType.Zone, "Zone Id");
            CoreParsers.WorldStateHandler.CurrentAreaId = packet.ReadEntry<Int32>(StoreNameType.Area, "Area Id");
            packet.ReadEntry<Int32>(StoreNameType.Map, "Map ID");

            var numFields = packet.ReadInt32("Field Count");
            for (var i = 0; i < numFields; i++)
                CoreParsers.WorldStateHandler.ReadWorldStateBlock(ref packet);
        }
    }
}
