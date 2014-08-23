using System;
using System.Data.SqlTypes;
using System.Text;
using Microsoft.SqlServer.Server;

/// <summary>
/// Code taken from http://www.mssqltips.com/sqlservertip/2022/concat-aggregates-sql-server-clr-function/
/// modified for better code quality and default delimiter support ,
/// </summary>
[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(

    Format.UserDefined, /// Binary Serialization because of StringBuilder
    IsInvariantToOrder = false, /// order changes the result
    IsInvariantToNulls = true,  /// nulls don't change the result
    IsInvariantToDuplicates = false, /// duplicates change the result
    MaxByteSize = -1)]

public struct Concat : IBinarySerialize
{
    private StringBuilder accumulator;
    private string delimiter;

    /// <summary>
    /// IsNull property
    /// </summary>
    public bool IsNull { get; private set; }

    public void Init()
    {
        this.accumulator = new StringBuilder();
        this.delimiter = string.Empty;
        this.IsNull = true;
    }
    
    public void Accumulate(SqlString value, SqlString delimiterParameter)
    {
        if (!delimiterParameter.IsNull
            & delimiterParameter.Value.Length > 0)
        {
            this.delimiter = delimiterParameter.Value; /// save for Merge
            if (this.accumulator.Length > 0)
            {
                this.accumulator.Append(delimiterParameter.Value);
            }
        }

        this.accumulator.Append(value.Value);
        if (value.IsNull == false)
        {
            this.IsNull = false;
        }
    }

    /// <summary>
    /// Merge onto the end 
    /// </summary>
    /// <param name="group"></param>
    public void Merge(Concat group)
    {
        /// add the delimiter between strings
        if (this.accumulator.Length > 0 & group.accumulator.Length > 0)
        {
            this.accumulator.Append(this.delimiter);
        }

        ///_accumulator += Group._accumulator;
        this.accumulator.Append(group.accumulator.ToString());
    }

    public SqlString Terminate()
    {
        // Put your code here
        return new SqlString(this.accumulator.ToString());
    }

    /// <summary>
    /// deserialize from the reader to recreate the struct
    /// </summary>
    /// <param name="reader">BinaryReader</param>
    void IBinarySerialize.Read(System.IO.BinaryReader reader)
    {
        this.delimiter = reader.ReadString();
        this.accumulator = new StringBuilder(reader.ReadString());

        if (this.accumulator.Length != 0)
        {
            this.IsNull = false;
        }
    }

    /// <summary>
    /// searialize the struct.
    /// </summary>
    /// <param name="writer">BinaryWriter</param>
    void IBinarySerialize.Write(System.IO.BinaryWriter writer)
    {
        writer.Write(this.delimiter);
        writer.Write(this.accumulator.ToString());
    }
}