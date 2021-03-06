// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Bion.IO
{
    /// <summary>
    ///  NumberConverter provides methods to read and write fixed and
    ///  variable length integers.
    /// </summary>
    public static class NumberConverter
    {
        public static void Write(this BufferedWriter writer, int value)
        {
            writer.EnsureSpace(4);
            writer.Buffer[writer.Index + 0] = (byte)value;
            writer.Buffer[writer.Index + 1] = (byte)(value >> 8);
            writer.Buffer[writer.Index + 2] = (byte)(value >> 16);
            writer.Buffer[writer.Index + 3] = (byte)(value >> 24);
            writer.Index += 4;
        }

        public static int ReadInt32(this BufferedReader reader)
        {
            reader.EnsureSpace(4);
            int value = (int)(reader.Buffer[reader.Index] | reader.Buffer[reader.Index + 1] << 8 | reader.Buffer[reader.Index + 2] << 16 | reader.Buffer[reader.Index + 3] << 24);
            reader.Index += 4;

            return value;
        }

        /// <summary>
        ///  Write value as a variable length, 7-bit encoded integer.
        ///  The last byte has a leading one bit, the others don't.
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <param name="writer">BufferedWriter to write to</param>
        public static void WriteSevenBitTerminated(BufferedWriter writer, ulong value)
        {
            writer.EnsureSpace(10);

            while (value > 0x7F)
            {
                writer.Buffer[writer.Index++] = (byte)(value & 0x7F);
                value = value >> 7;
            }

            writer.Buffer[writer.Index++] = (byte)(value | 0x80);
        }

        /// <summary>
        ///  Read the next bytes from the reader as a variable length,
        ///  7-bit encoded integer.
        /// </summary>
        /// <param name="reader">BufferedReader to read from</param>
        /// <returns>Value read</returns>
        public static ulong ReadSevenBitTerminated(BufferedReader reader)
        {
            reader.EnsureSpace(10);

            ulong value = 0;
            int current = 0, shift = 0;

            while (current <= 0x7F)
            {
                current = reader.Buffer[reader.Index++];
                value += (ulong)(current & 0x7F) << shift;
                shift += 7;
            }

            return value;
        }

        /// <summary>
        ///  Write value as a variable length, 6-bit encoded integer.
        ///  All bytes start with a zero bit. The last byte starts with
        ///  01, the others start with 00.
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <param name="writer">BufferedWriter to write to</param>
        public static void WriteSixBitTerminated(BufferedWriter writer, ulong value)
        {
            writer.EnsureSpace(11);

            while (value > 0x3F)
            {
                writer.Buffer[writer.Index++] = (byte)(value & 0x3F);
                value = value >> 6;
            }

            writer.Buffer[writer.Index++] = (byte)(value | 0x40);
        }

        /// <summary>
        ///  Read the next bytes from the reader as a variable length,
        ///  6-bit encoded integer.
        /// </summary>
        /// <param name="reader">BufferedReader to read from</param>
        /// <returns>Value read</returns>
        public static ulong ReadSixBitTerminated(BufferedReader reader)
        {
            reader.EnsureSpace(11);

            ulong value = 0;
            int current = 0, shift = 0;

            while (current <= 0x3F)
            {
                current = reader.Buffer[reader.Index++];
                value += (ulong)(current & 0x3F) << shift;
                shift += 6;
            }

            return value;
        }

        /// <summary>
        ///  Read the next bytes from the reader as a variable length,
        ///  6-bit encoded integer.
        /// </summary>
        /// <param name="reader">BufferedReader to read from</param>
        /// <returns>Value read</returns>
        public static int ReadSixBitTerminatedBlock(BufferedReader reader, ulong[] block)
        {
            reader.EnsureSpace(block.Length * 11);

            int index = 0;
            while (index < block.Length && !reader.EndOfStream)
            {
                ulong value = 0;
                int current = 0, shift = 0;

                while (current <= 0x3F)
                {
                    current = reader.Buffer[reader.Index++];
                    value += (ulong)(current & 0x3F) << shift;
                    shift += 6;
                }

                block[index++] = value;
            }

            return index;
        }

        /// <summary>
        ///  Write value as a fixed length, 7-bit encoded integer.
        ///  All bytes start with a zero bit.
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <param name="length">Byte length to write</param>
        /// <param name="writer">BufferedWriter to write to</param>
        public static void WriteSevenBitFixed(BufferedWriter writer, ulong value, int length)
        {
            writer.EnsureSpace(length);

            for (int i = 0; i < length; ++i)
            {
                writer.Buffer[writer.Index++] = (byte)(value & 0x7F);
                value = value >> 7;
            }
        }

        /// <summary>
        ///  Read the next bytes from the reader as a fixed length
        ///  7-bit encoded integer.
        /// </summary>
        /// <param name="reader">BufferedReader to read from</param>
        /// <param name="length">Byte length of value</param>
        /// <returns>Value read</returns>
        public static ulong ReadSevenBitFixed(BufferedReader reader, int length)
        {
            reader.EnsureSpace(length);

            ulong value = 0;
            int shift = 0;

            for (int i = 0; i < length; ++i)
            {
                value += (ulong)(reader.Buffer[reader.Index++] & 0x7F) << shift;
                shift += 7;
            }

            return value;
        }

        /// <summary>
        ///  Write value as a variable length, 7-bit encoded integer.
        ///  All bytes begin with a 0 bit.
        ///  The length is returned separately and must be known to read.
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <param name="writer">BufferedWriter to write to</param>
        public static byte WriteSevenBitExplicit(BufferedWriter writer, ulong value)
        {
            writer.EnsureSpace(10);

            int start = writer.Index;
            while (value > 0x7F)
            {
                writer.Buffer[writer.Index++] = (byte)(value & 0x7F);
                value = value >> 7;
            }

            writer.Buffer[writer.Index++] = (byte)(value);
            return (byte)(writer.Index - start);
        }

        /// <summary>
        ///  Read the next bytes from the reader as a variable length,
        ///  7-bit encoded integer.
        /// </summary>
        /// <param name="reader">BufferedReader to read from</param>
        /// <returns>Value read</returns>
        public static ulong ReadSevenBitExplicit(BufferedReader reader, int length)
        {
            reader.EnsureSpace(length);

            ulong value = 0;
            int shift = 0;

            for(int i = 0; i < length; ++i)
            {
                value += (ulong)(reader.Buffer[reader.Index++] & 0x7F) << shift;
                shift += 7;
            }

            return value;
        }

        public static void WriteIntBlock(BufferedWriter writer, int[] values, int length)
        {
            int byteLength = 4 * length;
            writer.EnsureSpace(byteLength);
            Buffer.BlockCopy(values, 0, writer.Buffer, writer.Index, byteLength);
            writer.Index += byteLength;
        }

        public static int ReadIntBlock(BufferedReader reader, int[] values, int length)
        {
            int available = Math.Min(4 * length, reader.EnsureSpace(4 * length));
            Buffer.BlockCopy(reader.Buffer, reader.Index, values, 0, available);
            reader.Index += available;
            return (available / 4);
        }
    }
}
