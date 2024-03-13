# Work in progress

#### Injecting the DLL in a PowerShell process:
```pwsh
Add-Type -path .\Discord-C2.dll
[DiscordC2.Server]::Start()
```

A .dc2 file containing your bot's token needs to be accessible in the folder where the application is going to run.
This is a temporary solution during development, it will be obfuscated to a much higher degree later
