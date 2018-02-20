using System;



namespace ClockCore
{

	/// <summary>
	///		This exception can only be thrown by the Song file Importer
	/// </summary>
	public class InvalidSongFileException : Exception
	{
		public InvalidSongFileException()
		{
			
		}

		public InvalidSongFileException(string message)
			: base(message)
		{
			message = "A Corrupted Song File Importing! so Bad :(";
		}

		public InvalidSongFileException(string message, Exception inner)
			: base(message, inner)
		{
			
		}
	}
}
