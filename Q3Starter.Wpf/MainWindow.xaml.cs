using JsonSettings;
using Q3Starter.Models;
using Q3Starter.Controllers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Q3Starter.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Settings? _settings = null;
    private ObservableCollection<MapInfoViewModel> _mapList = new ObservableCollection<MapInfoViewModel>();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            _settings = JsonSettingsBase.Load<Settings>();

            tbGameExe.Text = _settings.GameExe;
            tbBasePath.Text = _settings.BasePath;
            nudFragLimit.Text = _settings[_settings.CurrentProfile].FragLimit.ToString();
            cbProfile.Text = _settings.CurrentProfile;

            FillMapList();
            FillProfileList();
            FillSelectedMaps();

            // Wire up change events
            tbGameExe.TextChanged += (s, ev) => { _settings?.GameExe = tbGameExe.Text; };
            tbBasePath.TextChanged += (s, ev) => { _settings?.BasePath = tbBasePath.Text; };
            cbProfile.SelectionChanged += (s, ev) => { if (_settings != null && cbProfile.SelectedItem != null) _settings.CurrentProfile = cbProfile.SelectedItem.ToString() ?? "default"; };
            nudFragLimit.TextChanged += (s, ev) => { if (_settings != null && int.TryParse(nudFragLimit.Text, out int val)) _settings[_settings.CurrentProfile].FragLimit = val; };

            if (!string.IsNullOrEmpty(_settings.CurrentProfile))
            {
                var profile = _settings[_settings.CurrentProfile];
                tbConfig.Text = ConfigBuilder.GetScriptContent(profile);
                lblSelected.Content = $"{profile?.Maps?.Count ?? 0} maps selected";
            }
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void FillProfileList()
    {
        cbProfile.Items.Clear();
        if (_settings?.Profiles?.Any() ?? false)
        {
            foreach (var profile in _settings.Profiles)
            {
                cbProfile.Items.Add(profile.Name);
            }
        }
    }

    private void FillMapList()
    {
        if (!Directory.Exists(_settings?.BasePath)) return;

        var maps = ConfigBuilder.GetMaps(_settings.BasePath);
        _mapList.Clear();
        foreach (var map in maps)
        {
            _mapList.Add(new MapInfoViewModel(map));
        }
        lbMaps.ItemsSource = _mapList;
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
        _settings?.Save();
    }

    private void lbMaps_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lbMaps.SelectedItem is MapInfoViewModel mapViewModel)
        {
            pictureBox1.Source = ConvertToImageSource(mapViewModel.MapInfo.Thumbnail);
        }
    }

    private void MapCheckBox_Changed(object sender, RoutedEventArgs e)
    {
        if (_settings == null) return;

        // Collect all checked maps
        var checkedMaps = new HashSet<string>();
        foreach (var item in _mapList)
        {
            if (item.IsSelected)
            {
                checkedMaps.Add(item.Name);
            }
        }

        _settings[_settings.CurrentProfile].Maps = checkedMaps;
        tbConfig.Text = ConfigBuilder.GetScriptContent(_settings[_settings.CurrentProfile]);
        lblSelected.Content = $"{checkedMaps.Count} maps selected";
    }

    private void cbProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_settings != null && cbProfile.SelectedItem != null)
        {
            _settings.CurrentProfile = cbProfile.SelectedItem.ToString() ?? "default";
            FillSelectedMaps();
        }
    }

    private void FillSelectedMaps()
    {
        if (_settings == null) return;

        var selectedMaps = _settings[_settings.CurrentProfile].Maps;
        foreach (var mapViewModel in _mapList)
        {
            mapViewModel.IsSelected = selectedMaps?.Contains(mapViewModel.Name) ?? false;
        }

        var profile = _settings[_settings.CurrentProfile];
        tbConfig.Text = ConfigBuilder.GetScriptContent(profile);
        lblSelected.Content = $"{profile?.Maps?.Count ?? 0} maps selected";
    }

    private void btnPlay_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_settings == null || string.IsNullOrEmpty(_settings.GameExe))
            {
                MessageBox.Show("Please specify the game executable path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ProcessStartInfo psi = new(_settings.GameExe);
            psi.WorkingDirectory = Path.GetDirectoryName(_settings.GameExe);
            psi.Arguments = $"+exec {ConfigBuilder.GetScriptFile(_settings[_settings.CurrentProfile], _settings.BasePath)}";
            Process.Start(psi);
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private static BitmapImage? ConvertToImageSource(System.Drawing.Image? image)
    {
        if (image == null) return null;

        var memory = new MemoryStream();
        image.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
        memory.Position = 0;
        
        var bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memory;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();
        bitmapImage.Freeze();
        
        return bitmapImage;
    }
}

public class MapInfoViewModel(MapInfo mapInfo) : INotifyPropertyChanged
{
    public MapInfo MapInfo { get; } = mapInfo;
    private bool _isSelected;

    public string Name => MapInfo.Name;

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}