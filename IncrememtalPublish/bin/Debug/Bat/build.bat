call D:\soft\vs2012\Common7\Tools\VsDevCmd.bat
set curdir=%~dp0
cd /d %curdir%
msbuild buildweb.xml
exit