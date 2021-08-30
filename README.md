<h1 align="center">
  <br>
  <a href="https://github.com/Inerska/Trixy"><img src="https://github.com/Inerska/Trixy/blob/main/vendors/bot_logo.png" alt="Trixy's logo"></a>
  <br>
  Trixy
  <br>
</h1>

<h4 align="center">A professional discord bot for a professional discord server.</h4>
<h5 align="center">Modulable, open-source, powerful, moderation, fun, socials, etc.</h5>


<p align="center">
  <a href="https://discord.gg/fNV7ZDFpq9">
    <img src="https://discordapp.com/api/guilds/881977494499123220/widget.png?style=shield" alt="Discord Server">
  </a>
  <a href="https://github.com/Nihlus/Remora.Discord">
     <img alt="Remora" src="https://img.shields.io/badge/made%20with-remora-blueviolet">
  </a>
  </a>
</p>

<p align="center">
  <a href="#overview">Overview</a>
  •
  <a href="#installation">Installation</a>
  •
  <a href="#invite">Invite the bot</a>
  •
  <a href="#support">Support server</a>
</p>

# Overview
Trixy is a discord bot made with ♥ powered with [Remora.Discord 🦈](https://github.com/Nihlus/Remora.Discord) by Nihlus. The bot is free for everyone, and mostly open-source, we encourage everyone to make pull request and contribute to the project. The goal of the project is to make a discord bot with a pretty good project structure and a clean source code (if you see something that can be improve, do not hesitate to contribute). It's an all-in-one bot, we want Trixy to contain the most features it can, moderation, social, administration tasks, etc. 

# Installation
To install Trixy within your discord server
* You can invite Trixy with the <a href="#invite">invite link</a>.
* You can self-host the discord bot, if so, please continue.

Made with a generic worker hoster, probably everybody can self-host Trixy easily, just assure to create a `Properties` directory inside `Trixy.BotWorker` and create a `launchSettings.json` file, and please follow this default pattern file :
```json
{
  "profiles": {
    "Trixy.BotWorker": {
      "commandName": "Project",
      "environmentVariables": {
        "NSFW_ANIME_API_BASE_URL_": "https://api.waifu.pics/nsfw/",
        "SFW_ANIME_API_BASE_URL_": "https:/api.waifu.pics/sfw/",
        "DOTNET_ENVIRONMENT": "Development",
        "TRIXY_": "your_bot_token_here",
        "CONNECTION_STRING_": "your_sqlite_connection_string_here"
      },
      "dotnetRunMessages": "true"
    }
  }
}
```

Then configure the `Trixy.BotWorker/appsettings.Development.json` file, make sure that `Trixy.BotWorker` is the startup-project before you launch, and Trixy can be operational !

# Invite
* To invite Trixy within your server, <a href="https://discord.com/api/oauth2/authorize?client_id=870605243891744859&permissions=8&scope=applications.commands%20bot">click here</a>
* If you are self-hosting Trixy you can catch its invite link by mentioning the bot itself.

# Support
Something wrong during your installation ? Do you have any idea ? Do you have encountered some issues ? Please join the support discord server by <a href="https://discord.gg/fNV7ZDFpq9">clicking here</a>

Please have fun, and make your discord server travel in another dimention of modernity-
