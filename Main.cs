using System;
using System.Windows.Forms;
using GraphForm;

class Program
{
	[STAThread]
	public static void Main (string[] args)
	{
		Application.EnableVisualStyles();
		Application.Run(new GraphForm.GraphForm());
	}
}
