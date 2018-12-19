using JsonSettings;
using Q3Starter.Controllers;
using Q3Starter.Models;
using Q3Starter.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q3Starter
{
	public partial class frmMain : Form
	{
		private QuakeSettings _settings = null;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			_settings = JsonSettingsBase.Load<QuakeSettings>();

			tbGameExe.Text = _settings.GameExe;
			tbBasePath.Text = _settings.BasePath;

			FillMapList();

			tbGameExe.Bind((t) => _settings.GameExe = t);
			tbBasePath.Bind((t) => _settings.BasePath = t);
		}

		private void FillMapList()
		{
			if (!Directory.Exists(_settings?.BasePath)) return;

			var maps = ConfigBuilder.GetMaps(_settings.BasePath);
			lbMaps.Items.Clear();
			lbMaps.DataSource = new BindingList<MapInfo>(maps);
			lbMaps.ValueMember = "Name";
			lbMaps.DisplayMember = "Name";
			
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			_settings.Save();
		}

		private void lbMaps_SelectedIndexChanged(object sender, EventArgs e)
		{
			var mapInfo = lbMaps.SelectedItem as MapInfo;
			if (mapInfo != null) pictureBox1.Image = mapInfo.Thumbnail;
		}
	}
}
