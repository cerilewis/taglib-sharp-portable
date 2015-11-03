//
// StreamFileAbstraction.cs:
//
// Author:
//   Tim Heuer (tim@timheuer.com)
//
// Copyright (C) 2014 Tim Heuer
//
// This library is free software; you can redistribute it and/or modify
// it  under the terms of the The MIT License (MIT).
//
// This library is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See The MIT License (MIT) for more details.
//
// You should have received a copy of The MIT License (MIT)
// along with this library.
//

using System.IO;

namespace TagLib
{
    public class StreamFileAbstraction : File.IFileAbstraction
    {
        private readonly Stream _readStream;

        private readonly Stream _writeStream;

        public StreamFileAbstraction(string name, Stream readStream, Stream writeStream)
        {
            // TODO: Fix deadlock when setting an actual writable Stream
            this._writeStream = readStream;
            this._readStream = readStream;
            Name = name;
        }

        public string Name { get; private set; }

        public Stream ReadStream
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("StreamFileAbstraction.ReadStream");
                return this._readStream;
            }
        }

        public Stream WriteStream
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("StreamFileAbstraction.WriteStream");
                return this._writeStream;
            }
        }

        public void CloseStream(Stream stream)
        {
            System.Diagnostics.Debug.WriteLine("StreamFileAbstraction.CloseStream");
            stream.Dispose();
        }
    }
}
