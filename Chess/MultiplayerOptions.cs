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
		public bool player2Assigned;
		public MultiplayerOptions()
		{
			player1Assigned = false;
			player2Assigned = false;
			InitializeComponent();
		}
	}
}
