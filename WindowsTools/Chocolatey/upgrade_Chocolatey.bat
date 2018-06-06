@ECHO OFF
choco upgrade chocolatey
IF %ERRORLEVEL% NEQ 0 (
  ECHO You must run the script in Administrative Mode
  GOTO ExitLabel
) ELSE ( 
 ECHO Upgrade complete. Enjoy it!
)
:ExitLabel
PAUSE
@ECHO ON