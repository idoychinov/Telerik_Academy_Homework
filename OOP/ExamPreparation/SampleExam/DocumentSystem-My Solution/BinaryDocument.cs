using System;

abstract class BinaryDocument : Document
{
    public BinaryDocument(string name)
        : base(name)
    {
    }

    public long Size { get; protected set; }
}

