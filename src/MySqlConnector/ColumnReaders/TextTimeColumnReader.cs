namespace MySqlConnector.ColumnReaders;
using System.Buffers.Text;
using MySqlConnector.Protocol.Payloads;
using MySqlConnector.Protocol.Serialization;
using MySqlConnector.Utilities;

internal sealed class TextTimeColumnReader : IColumnReader
{
	internal static TextTimeColumnReader Instance { get; } = new TextTimeColumnReader();

	public object ReadValue(ReadOnlySpan<byte> data, ColumnDefinitionPayload columnDefinition)
	{
		return Utility.ParseTimeSpan(data);
	}

	public int ReadInt32(ReadOnlySpan<byte> data, ColumnDefinitionPayload columnDefinition)
	{
		throw new InvalidCastException($"Can't convert {columnDefinition.ColumnType} to Int32");
	}
}