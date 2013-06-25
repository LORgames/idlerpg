@echo off
set PAUSE_ERRORS=1
call bat\SetupSDK.bat
call bat\SetupApplication.bat

:target
goto desktop
::goto android-debug
::goto android-test
::goto windows-package
set INTERPRETER=-interpreter
::goto ios-debug
::goto ios-test

:desktop
:: http://help.adobe.com/en_US/air/build/WSfffb011ac560372f-6fa6d7e0128cca93d31-8000.html

::set SCREEN_SIZE=NexusOne
set SCREEN_SIZE=iPhone5Retina

:desktop-run
echo.
echo Starting AIR Debug Launcher.
echo.
echo (hint: edit 'Run.bat' to test on device or change screen size)
echo.
::adl -screensize %SCREEN_SIZE% "%APP_XML%" "%APP_DIR%"
adl "%APP_XML%" "%APP_DIR%" -- map=Tortuga Pirate City

if errorlevel 1 goto end
goto end


:ios-debug
echo.
echo Packaging application for debugging on iOS %INTERPRETER%
if "%INTERPRETER%" == "" echo (this will take a while)
echo.
set TARGET=-debug%INTERPRETER%
set OPTIONS=-connect %DEBUG_IP%
goto ios-package

:ios-test
echo.
echo Packaging application for testing on iOS %INTERPRETER%
if "%INTERPRETER%" == "" echo (this will take a while)
echo.
set TARGET=-test%INTERPRETER%
set OPTIONS=
goto ios-package

:ios-package
set PLATFORM=ios
call bat\Packager.bat

if "%AUTO_INSTALL_IOS%" == "yes" goto ios-install
echo Now manually install and start application on device
echo.
goto end

:ios-install
echo Installing application for testing on iOS (%DEBUG_IP%)
echo.
call adt -installApp -platform ios -package "%OUTPUT%"
if errorlevel 1 goto installfail

echo Now manually start application on device
echo.
goto end

:android-debug
echo.
echo Packaging and installing application for debugging on Android (%DEBUG_IP%)
echo.
set TARGET=-debug -listen
set OPTIONS=
goto android-package

:android-test
echo.
echo Packaging and Installing application for testing on Android (%DEBUG_IP%)
echo.
set TARGET=
set OPTIONS=
goto android-package

:android-package
set PLATFORM=android
call bat\Packager.bat

adb devices
echo.
echo Installing %OUTPUT% on the device...
echo.
adb -d install -r "%OUTPUT%"
if errorlevel 1 goto installfail

if not "%TARGET%"=="-debug -listen" goto android-run

adb forward tcp:7936 tcp:7936
adb shell am start -n air.%APP_ID%/.AppEntry
fdb -p 7936
goto end

:android-run
echo.
echo Starting application on the device for debugging...
echo.
adb shell am start -n air.%APP_ID%/.AppEntry
goto end

:windows-package
set PLATFORM=native
call bat\Packager.bat

set PLATFORM=windows
call bat\Packager.bat

goto end

:installfail
echo.
echo Installing the app on the device failed
goto end

:failedair
echo AIR setup creation FAILED.
echo.
goto end

:end
pause
