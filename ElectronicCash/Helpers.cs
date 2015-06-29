﻿using System;

namespace ElectronicCash
{
    /// <summary>
    /// Contains all our helper methods to help keep our classes cleaner,
    /// and make unit testing possible
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// stackoverflow.com/questions/472906/converting-a-string-to-byte-array-without-using-an-encoding-byte-by-byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns />
        public static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// stackoverflow.com/questions/472906/converting-a-string-to-byte-array-without-using-an-encoding-byte-by-byte
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns />
        public static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        /// <summary>
        /// A simple way to concatenate byte arrays. See http://stackoverflow.com/a/415396. Used for
        /// bit commitment.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static byte[] ConcatByteArrays(byte[] left, byte[] right)
        {
            var concatenated = new byte[left.Length + right.Length];
            Buffer.BlockCopy(left, 0, concatenated, 0, left.Length);
            Buffer.BlockCopy(right, 0, concatenated, left.Length, right.Length);

            return concatenated;
        }
    }
}
