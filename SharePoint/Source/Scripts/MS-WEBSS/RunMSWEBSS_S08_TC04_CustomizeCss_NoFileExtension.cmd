@echo off
pushd %~dp0
"%VS120COMNTOOLS%..\IDE\mstest" /test:Microsoft.Protocols.TestSuites.MS_WEBSS.S08_OperationsOnCSS.MSWEBSS_S08_TC04_CustomizeCss_NoFileExtension /testcontainer:..\..\MS-WEBSS\TestSuite\bin\Debug\MS-WEBSS_TestSuite.dll /runconfig:..\..\MS-WEBSS\MS-WEBSS.testsettings /unique
pause