﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Leviathan.Data.Interfaces;
using Windows.Storage.Streams;

namespace Leviathan.Data
{
    public class FileDataProvider : IDataProvider
    {

        public async Task<byte[]> LoadDataAsync(StorageFile file)
        {
            var buffer = await FileIO.ReadBufferAsync(file);

            using var reader = DataReader.FromBuffer(buffer);

            var bytes = new byte[buffer.Length];
            reader.ReadBytes(bytes);
            return bytes;
        }

        public async Task<string> SaveDataAsync(StorageFile file, IWriter writer, Encoding encoding)
        {
            try
            {
                var bytes = writer.GetBytes(encoding);

                // Create sample file; replace if exists.
                await FileIO.WriteBytesAsync(file, bytes);
                
                return $"{file.Name} was saved.";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
