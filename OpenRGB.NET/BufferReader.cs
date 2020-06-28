﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRGB.NET
{
    internal static class BufferReader
    {
        internal static int GetInt32(byte[] buffer, ref int offset)
        {
            int value = BitConverter.ToInt32(buffer, offset);
            offset += sizeof(int);
            return value;
        }

        internal static uint GetUInt32(byte[] buffer, ref int offset)
        {
            uint value = BitConverter.ToUInt32(buffer, offset);
            offset += sizeof(uint);
            return value;
        }

        internal static ushort GetUInt16(byte[] buffer, ref int offset)
        {
            ushort value = BitConverter.ToUInt16(buffer, offset);
            offset += sizeof(ushort);
            return value;
        }

        internal static string GetString(byte[] buffer, ref int offset)
        {
            ushort strLength = GetUInt16(buffer, ref offset);
            return GetStringWithLength(buffer, ref offset, strLength);
        }

        private static string GetStringWithLength(byte[] buffer, ref int offset, int length)
        {
            var value = Encoding.ASCII.GetString(buffer, offset, length - 1);
            offset += length;
            return value;
        }
    }
}