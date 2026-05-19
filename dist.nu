#!/usr/bin/nu

let version = "1.0.0"
let bepinex_url = "https://github.com/BepInEx/BepInEx/releases/download/v5.4.23.5/BepInEx_win_x64_5.4.23.5.zip"
let script_loader_url = "https://github.com/ghorsington/BepInEx.ScriptLoader/releases/download/v1.2.4.0/ScriptLoader.dll"
let zip_filename = $"CoS_GamepadFix_($version).zip"

http get $bepinex_url | save --force --progress $zip_filename
^zip -r $zip_filename scripts/

let plugins_path = "BepInEx/plugins"
let script_loader_path = $"($plugins_path)/ScriptLoader.dll"

mkdir $plugins_path
http get $script_loader_url | save --force --progress $script_loader_path
^zip -r $zip_filename "BepInEx"

