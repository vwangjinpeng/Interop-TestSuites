@echo off
pushd %~dp0
"%VS120COMNTOOLS%..\IDE\mstest" /test:Microsoft.Protocols.TestSuites.MS_ASCMD.S08_ItemOperations.MSASCMD_S08_TC07_ItemOperations_MultiplePartResponse /testcontainer:..\..\MS-ASCMD\TestSuite\bin\Debug\MS-ASCMD_TestSuite.dll /runconfig:..\..\MS-ASCMD\MS-ASCMD.testsettings /unique
pause