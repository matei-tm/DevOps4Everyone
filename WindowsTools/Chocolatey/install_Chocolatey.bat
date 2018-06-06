@ECHO OFF
ECHO Chocolatey is a package manager for Windows (like apt-get or yum but for Windows)
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"
IF %ERRORLEVEL% NEQ 0 (
  ECHO You must run the script in Administrative Mode
  GOTO ExitLabel
) ELSE ( 
 ECHO Installation complete. Enjoy it!
)
:ExitLabel
PAUSE
@ECHO ON