using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
	public partial class MultiplayerOptions : Form
	{
		public bool player1Assigned;
		public string player1Name;
		public bool player2Assigned;
		public string player2Name;
		public MultiplayerOptions()
		{
			player1Name = "";
			player2Name = "";
			player1Assigned = false;
			player2Assigned = false;
			InitializeComponent();
		}
	}
}
