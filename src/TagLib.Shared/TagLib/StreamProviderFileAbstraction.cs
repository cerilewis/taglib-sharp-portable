namespace TagLib
{
    using System;
    using System.IO;

    public class StreamProviderFileAbstraction : File.IFileAbstraction
    {
        private readonly Func<Stream> _createStream;

        public StreamProviderFileAbstraction(string name, Func<Stream> createStream)
        {
            this._createStream = createStream;
            this.Name = name;
        }

        public string Name { get; }

        public Stream ReadStream => this._createStream();

        public Stream WriteStream => this._createStream();

        public void CloseStream(Stream stream)
        {
            stream.Dispose();
        }
    }
}