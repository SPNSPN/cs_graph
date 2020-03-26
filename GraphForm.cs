using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.IO.Ports;
using System.Text;

namespace GraphForm
{
class GraphForm : Form
{
	private Chart chart;
	private Button log_btn;
	private Button open_btn;
	private TextBox port_text;
	private TextBox log_text;

	private SerialPort serial;
	private double[] data;

	private void open_Click (object sender, EventArgs e)
	{
		this.serial.PortName = this.port_text.Text;
		this.serial.Open();
	}

	private void log_Click (object sender, EventArgs e)
	{
		File.WriteAllText(".\\log.csv", String.Join(", ", this.data));
	}

	public GraphForm ()
	{
		this.Size = new Size(800, 600);

		this.log_btn = new Button();
		this.log_btn.Text = "LOG";
		this.log_btn.Click += new EventHandler(this.log_Click);
		this.log_btn.Dock = DockStyle.Bottom;
		this.log_btn.Size = new Size(0, 25);

		this.open_btn = new Button();
		this.open_btn.Text = "OPEN";
		this.open_btn.Click += new EventHandler(this.open_Click);
		this.open_btn.Dock = DockStyle.Bottom;
		this.open_btn.Size = new Size(0, 25);

		this.chart = new Chart();
		this.chart.ChartAreas.Add(new ChartArea("area"));
		this.chart.Series.Add("series");
		this.chart.Series["series"].ChartType = SeriesChartType.Line;

		this.data = new double[] {0.00, 0.18, 0.15, -0.05, 0.02};
		for (int i = 0; i < this.data.Length; ++i)
		{
			this.chart.Series["series"].Points.AddY(this.data[i]);
		}

		this.port_text = new TextBox();
		this.port_text.Dock = DockStyle.Bottom;

		this.log_text = new TextBox();
		this.log_text.Dock = DockStyle.Bottom;

		this.serial = new SerialPort();
		this.serial.BaudRate = 115200;
		this.serial.Parity = Parity.None;
		this.serial.DataBits = 8;
		this.serial.StopBits = StopBits.One;
		this.serial.Handshake = Handshake.None;

		this.Controls.Add(this.port_text);
		this.Controls.Add(this.open_btn);
		this.Controls.Add(this.log_text);
		this.Controls.Add(this.log_btn);
		this.Controls.Add(this.chart);
	}
}
}

