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
		
		public Logs(string[] Text, Font Font, Color clr, Form Form)
		{
			this.Data = Text;
			this.Font = Font;
			this.Form = Form;
			contr.Font = Font;
			contr.Text = string.Join("\n", Data);
			contr.ForeColor = Color.White;
			contr.AutoSize = true;
			contr.Location = new Point(0, 0);
            contr.ForeColor = clr;
		}
		
		public void Show(int ms)
		{
			System.Timers.Timer a = new System.Timers.Timer();
            System.Windows.Forms.Timer ontop = new System.Windows.Forms.Timer();
            a.Interval = ms;
			a.Elapsed += (object s, System.Timers.ElapsedEventArgs e) =>
			{
				Form.Controls.Remove(contr);
                ontop.Stop();
                ontop.Dispose();
                a.Dispose();
			};
            ontop.Interval = 10;
            ontop.Tick += (object se, EventArgs e) =>
            {
                foreach (Control s in Form.Controls)
                    if (s != contr)
                        s.SendToBack();
            };
            ontop.Enabled = true;
            ontop.Start();
			Form.Controls.Add(contr);
			a.Start();
		}
	}
}
