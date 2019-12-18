﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Leviathan.Data.Interfaces;

namespace Leviathan.Data
{
    public class EncodingReader : IReader
    {
        private readonly List<byte[]> _bytes = new List<byte[]>();

        public string Read(EncodingProvider encodingProvider, string encodingName)
        {
            var bytes = _bytes.SelectMany(item => item);

            return encodingProvider.GetEncoding(encodingName).GetString(bytes.ToArray());
        }

        public string Read(Encoding encoding)
        {
            var bytes = _bytes.SelectMany(item => item);

            return encoding.GetString(bytes.ToArray());
        }

        public int AddBytes(byte[] data)
        {
            _bytes.Add(data);
            return _bytes.SelectMany(item => item).ToArray().Length;
        }
    }
}