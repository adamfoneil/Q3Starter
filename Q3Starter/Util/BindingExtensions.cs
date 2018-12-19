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

		public static void Bind(this NumericUpDown numericUpDown, Action<decimal> setProperty)
		{
			numericUpDown.ValueChanged += delegate (object sender, EventArgs e)
			{
				setProperty.Invoke(numericUpDown.Value);
			};
		}

		public static void Bind<T>(this ComboBox comboBox, Action<T> setProperty) where T : class
		{
			comboBox.SelectedIndexChanged += delegate (object sender, EventArgs e)
			{
				T value = comboBox.SelectedItem as T;
				setProperty.Invoke(value);
			};
		}
	}
}