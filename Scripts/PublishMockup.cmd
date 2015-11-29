rmdir "C:\inetpub\wwwroot\mockup" /s /q
mkdir "C:\inetpub\wwwroot\mockup"
xcopy "..\Mockup" "C:\inetpub\wwwroot\mockup" /E

Pause