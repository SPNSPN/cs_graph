using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphForm
{
class GraphForm : Form
{
	private Chart chart;

	public GraphForm ()
	{
		this.chart = new Chart();
		this.chart.ChartAreas.Add(new ChartArea("area"));
		this.chart.Series.Add("series");
		this.chart.Series["series"].ChartType = SeriesChartType.Line;

		double[] ys = new double[] {0.00, 0.18, 0.15, -0.05, 0.02};
		for (int i = 0; i < ys.Length; ++i)
		{
			this.chart.Series["series"].Points.AddY(ys[i]);
		}
		this.Controls.Add(this.chart);
	}
}
}

