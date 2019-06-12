using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	[Serializable]
	public class Move
	{
		public Tuple<int, int> startIndex { get; set; }
		public Tuple<int, int> endIndex { get; set; }

		public override string ToString()
		{
			StringBuilder move = new StringBuilder();
			move.Append(startIndex.ToString());
			move.Append(':');
			move.Append(endIndex.ToString());
			return move.ToString();
		}
	}
	public class Logger
	{
		IFormatter formatter;
		private const string MovesLogFileName = "MovesLog";
		public Logger()
		{
			formatter = new BinaryFormatter();
			Stream stream = new FileStream(MovesLogFileName, FileMode.Create, FileAccess.Write);
			stream.Close();
		}


		public void LogMove(Move move)
		{
			Stream stream = new FileStream(MovesLogFileName, FileMode.OpenOrCreate, FileAccess.Write);
			stream.Position = stream.Length;
			formatter.Serialize(stream, move);
			stream.Close();
		}

		public List<Move> ReadMoveLog()
		{
			Stream stream = new FileStream(MovesLogFileName, FileMode.Open, FileAccess.Read);
			List<Move> movesLog = new List<Move>();
			while(stream.Position < stream.Length)
			{
				movesLog.Add((Move)formatter.Deserialize(stream));
			}
			stream.Close();
			return movesLog;
		}
	}
}
