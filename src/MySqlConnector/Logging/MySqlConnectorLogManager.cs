namespace MySqlConnector.Logging;

/// <summary>
/// Controls logging for MySqlConnector.
/// </summary>
public static class MySqlConnectorLogManager
{
	/// <summary>
	/// Allows the <see cref="IMySqlConnectorLoggerProvider"/> to be set for this library. <see cref="Provider"/> can
	/// be set once, and must be set before any other library methods are used.
	/// </summary>
#pragma warning disable CA1044 // Properties should not be write only
	public static IMySqlConnectorLoggerProvider Provider
	{
		internal get
		{
			s_providerRetrieved = true;
			return s_provider;
		}
		set
		{
			if (s_providerRetrieved)
				throw new InvalidOperationException("The logging provider must be set before any MySqlConnector methods are called.");

			s_provider = value;
		}
	}

	internal static IMySqlConnectorLogger CreateLogger(string name) => Provider.CreateLogger(name);

	private static IMySqlConnectorLoggerProvider s_provider = new NoOpLoggerProvider();
	private static bool s_providerRetrieved;
}
