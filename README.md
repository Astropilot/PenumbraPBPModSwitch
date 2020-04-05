<h1 align="center">
  <br>
  <img src="https://raw.githubusercontent.com/Astropilot/PenumbraPBPModSwitch/master/images/bpb.jpg" alt="Penumbra Black Plague" width="400">
</h1>

<h4 align="center">
Penumbra Black Plague - Mod Switch</h4>

<p align="center">
  <a href="https://github.com/Astropilot/PenumbraPBPModSwitch/releases/latest"><img src="https://img.shields.io/github/release/Astropilot/PenumbraPBPModSwitch.svg" alt="Version"></a>
  <a href="https://github.com/Astropilot/PenumbraPBPModSwitch/issues">
    <img src="https://img.shields.io/github/issues/Astropilot/PenumbraPBPModSwitch"
         alt="Issues">
  </a>
  <a href="https://github.com/Astropilot/PenumbraPBPModSwitch/pulls">
    <img src="https://img.shields.io/github/issues-pr-raw/Astropilot/PenumbraPBPModSwitch"
         alt="Issues">
  </a>
  <img src="https://img.shields.io/badge/Made%20with-%E2%9D%A4%EF%B8%8F-yellow.svg">
</p>

<p align="center">
  <a href="#about">About</a> •
  <a href="#usage">Usage</a> •
  <a href="#contributing">Contributing</a> •
  <a href="#authors">Authors</a> •
  <a href="#license">License</a>
</p>

## About

This repository contains the C# project of this utility. It needs the [Memory.dll](https://github.com/erfg12/memory.dll) dependency which is installed via the NuGet Packets Manager.

This utility was developed with OOB maps in mind. The goal is to be able to switch from official maps to OOB maps without manipulating folders (including the game cache) and without having to restart the game.

This tool supports the following versions of Penumbra Black Plague:
* The Steam version
* The GOG version with the [1.1 patch](https://www.frictionalgames.com/forum/thread-24333.html)

## Usage

* First of all download the latest version (compressed archive) you can find [here](https://github.com/Astropilot/PenumbraPBPModSwitch/releases/latest).
* Then move the files and the `mods` folder to your game folder in the same place as Penumbra.exe (in the `redist` folder). The game path can be found via Steam: Properties -> Local files -> Browse local files...<br>
The path generally used by Steam is `C:\Program Files (x86)\Steam\steamapps\common\Penumbra Black Plague\redist`.<br>
* Launch Penumbra and once on the game menu you can launch the utility. Respect this order because the utility will try to initialize itself at startup and therefore need the game open at that time.
* It should load for a few seconds and when the files appear in the list everything is ready!
* You can then choose the modded files to activate simply by checking them.
* ***Warning***: It is very important to leave the box "Prevent the game to cache files" checked when using modded maps or it could lead to disastrous consequences for your game. You can safely uncheck it if you disable all modded maps to close the program and continue to use the game normally.
* Note: since the program prevents the game from using its cache system to avoid any problems, loading the maps takes longer than usual and can be more resource-intensive since it has to reload all the files each time.

You can find below the link of a tutorial video on Youtube in French with English subtitles:

<p align="center">
<a href="http://www.youtube.com/watch?feature=player_embedded&v=YOUTUBE_VIDEO_ID_HERE" target="_blank">
  <img src="http://img.youtube.com/vi/YOUTUBE_VIDEO_ID_HERE/0.jpg" width="240" height="180" border="10">
</a>
</p>

## Contributing

I would be happy to see you contribute to the development of this tool!

You can open a issue in case of a problem or fork this repository to propose a modification via a pull request.

## Authors

|               | Github profile                                        | Discord                                             |
|---------------|:-----------------------------------------------------:|:---------------------------------------------------:|
| Astropilot    | [Astropilot](https://github.com/Astropilot)           | Темный код#2347                                     |

## License

MIT - See LICENSE file
