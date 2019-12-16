﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leviathan.Data.Interfaces;

namespace Leviathan.Data
{
    public class EncodingWriter : IWriter
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public int Write(string text)
        {
            _sb.Append(text);
            
            return _sb.Length;
        }

        public byte[] GetBytes(EncodingProvider encodingProvider, string encodingName)
        {
            return encodingProvider.GetEncoding(encodingName).GetBytes(_sb.ToString());
        }

        public byte[] GetBytes(Encoding encoding)
        {
            var bytes = encoding.GetBytes(_sb.ToString());

            return bytes;
        }
    }
}
