# Q3Starter

I had used something in the past called Q3Launcher, I think, but I was having a hard time finding it. I'd started playing Q3 single-player again recently, and needed a way to set up map rotation. I had other things I needed to be working on, so of course it was time to make my own utility for this.

Only the bare-bones functionality works at this point. I can view the map list and select them for rotation, but there's no bot control, and way to select the game type. The profile dropdown (currently says "default") doesn't do what it's intended.

This was an opportunity to practice structuring a WinForms app cleanly, to experiment with an [easier form data binding](https://github.com/adamosoftware/Q3Starter/blob/master/Q3Starter/Util/BindingExtensions.cs) (used [here](https://github.com/adamosoftware/Q3Starter/blob/master/Q3Starter/frmMain.cs#L39)), to leverage my [JsonSettings](https://github.com/adamosoftware/JsonSettings) project. This project also involved reading and [working with zip files](https://github.com/adamosoftware/Q3Starter/blob/master/Q3Starter/Controllers/ConfigBuilder.cs#L14), since that's how Quake3 maps are packaged.

![img](https://adamosoftware.blob.core.windows.net:443/images/Q3starter.PNG)

The map rotation script is generated [here](https://github.com/adamosoftware/Q3Starter/blob/master/Q3Starter/Controllers/ConfigBuilder.cs#L102), which had help from [this thread](https://www.quake3world.com/forum/viewtopic.php?f=7&t=53280).
