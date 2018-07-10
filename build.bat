:myPOSTTest
--@echo off
cd %1
if not exist "%1build.count" >"%1build.count" echo 0
for /f %%x in (%1build.count) do (
set /a var=%%x+1
)
>%1build.count echo %var%

del %1%2.buildcount
echo|set /p=build > %1%2.buildcount
type %1build.count >> %1%2.buildcount
goto:eof

REM Thsi doesn't work with spaces...