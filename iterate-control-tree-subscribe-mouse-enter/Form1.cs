using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iterate_control_tree_subscribe_mouse_enter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
			IterateControlTree();
        }

		void IterateControlTree(Control control = null)
		{
			if (control == null)
			{
				control = this;
			}
			control.MouseEnter += Any_MouseEnter;
			foreach (Control child in control.Controls)
			{
				IterateControlTree(child);
			}
		}

		private void Any_MouseEnter(object sender, EventArgs e)
		{
			Control control = sender as Control;
			if(control != null)
			{
				string name = control.Name;
				if(string.IsNullOrWhiteSpace(name))
				{
					name = "NameNotSet";
				}
				Debug.WriteLine("MouseEnter detected: " + name);
			}
		}
	}
}
