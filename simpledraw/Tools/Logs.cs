// etar125
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace SimpleDraw.Tools
{
	public class Logs
	{
		public string[] Data;
		public Font Font;
		public Label contr = new Label();
		public Form Form;
		
		public Logs() { }
		
		public Logs(string[] Data, Font Font, Form Form)
		{
			this.Data = Data;
			this.Font = Font;
			this.Form = Form;
			contr.Font = Font;
			contr.Text = string.Join("\n", Data);
			contr.ForeColor = Color.White;
			contr.AutoSize = true;
			contr.Location = new Point(0, 0);
		}
		
		public void Show(int ms)
		{
			System.Timers.Timer a = new System.Timers.Timer();
			a.Interval = ms;
			a.Elapsed += (object s, System.Timers.ElapsedEventArgs e) =>
			{
				Form.Controls.Remove(contr);
				a.Dispose();
			};
			Form.Controls.Add(contr);
			a.Start();
		}
	}
}
