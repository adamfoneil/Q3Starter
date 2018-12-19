using System;
using System.Windows.Forms;

namespace Q3Starter.Util
{
	public static class BindingExtensions
	{
		public static void Bind(this TextBox textBox, Action<string> setProperty)
		{
			textBox.TextChanged += delegate (object sender, EventArgs e)
			{
				setProperty.Invoke(textBox.Text);
			};
		}
	}
}