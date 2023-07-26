using JsonSettings;
using Q3Starter.Controllers;
using Q3Starter.Models;
using Q3Starter.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Q3Starter
{
    public partial class frmMain : Form
    {
        private Settings _settings = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _settings = JsonSettingsBase.Load<Settings>();

                tbGameExe.Text = _settings.GameExe;
                tbBasePath.Text = _settings.BasePath;
                nudFragLimit.Value = _settings[_settings.CurrentProfile].FragLimit;
                cbProfile.Text = _settings.CurrentProfile;

                FillMapList();
                FillProfileList();
                FillSelectedMaps();

                tbGameExe.Bind((val) => _settings.GameExe = val);
                tbBasePath.Bind((val) => _settings.BasePath = val);
                cbProfile.Bind<string>((val) => _settings.CurrentProfile = val);
                nudFragLimit.Bind((val) => _settings[_settings.CurrentProfile].FragLimit = Convert.ToInt32(val));

                if (!string.IsNullOrEmpty(_settings.CurrentProfile))
                {
                    var profile = _settings[_settings.CurrentProfile];
                    tbConfig.Text = ConfigBuilder.GetScriptContent(profile);
                    lblSelected.Text = $"{profile?.Maps?.Count ?? 0} maps selected";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void FillProfileList()
        {
            cbProfile.Items.Clear();
            if (!_settings?.Profiles.Any() ?? true) return;
            foreach (var profile in _settings.Profiles) cbProfile.Items.Add(profile.Name);
        }

        private void FillMapList()
        {
            if (!Directory.Exists(_settings?.BasePath)) return;

            var maps = ConfigBuilder.GetMaps(_settings.BasePath);
            lbMaps.Items.Clear();
            lbMaps.DataSource = new BindingList<MapInfo>(maps.ToList());
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

        private void lbMaps_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var maps = _settings[_settings.CurrentProfile].Maps;

            if (maps == null)
            {
                maps = new HashSet<string>();
            }

            var selected = (lbMaps.Items[e.Index] as MapInfo).Name;
            if (e.NewValue == CheckState.Checked)
            {
                maps.Add(selected);
            }
            else
            {
                maps.Remove(selected);
            }

            _settings[_settings.CurrentProfile].Maps = maps;
            tbConfig.Text = ConfigBuilder.GetScriptContent(_settings[_settings.CurrentProfile]);
            lblSelected.Text = $"{maps.Count} maps selected";
        }

        private void cbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.CurrentProfile = cbProfile.SelectedItem.ToString();
            FillSelectedMaps();
        }

        private void FillSelectedMaps()
        {
            // prevent updates to settings file
            lbMaps.ItemCheck -= lbMaps_ItemCheck;

            lbMaps.SelectedIndices.Clear();
            if (_settings[_settings.CurrentProfile].Maps != null)
            {
                foreach (var mapName in _settings[_settings.CurrentProfile].Maps)
                {
                    var index = lbMaps.FindString(mapName);
                    if (index < 0) continue;
                    lbMaps.SetItemChecked(index, true);
                }
            }

            // re-enable event handling
            lbMaps.ItemCheck += lbMaps_ItemCheck;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(_settings.GameExe);
                psi.Arguments = $"+exec {ConfigBuilder.GetScriptFile(_settings[_settings.CurrentProfile], _settings.BasePath)}";
                Process.Start(psi);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}