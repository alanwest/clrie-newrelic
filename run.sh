#!/bin/bash
COR_ENABLE_PROFILING=1 \
COR_PROFILER={324F817A-7420-4E6D-B3C1-143FBED6D855} \
COR_PROFILER_PATH_32=InstrumentationEngine\\Instrumentation32\\MicrosoftInstrumentationEngine_x86.dll \
COR_PROFILER_PATH_64=InstrumentationEngine\\Instrumentation64\\MicrosoftInstrumentationEngine_x64.dll \
CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={324F817A-7420-4E6D-B3C1-143FBED6D855}
CORECLR_PROFILER_PATH_32=InstrumentationEngine\\Instrumentation32\\MicrosoftInstrumentationEngine_x86.dll \
CORECLR_PROFILER_PATH_64=InstrumentationEngine\\Instrumentation64\\MicrosoftInstrumentationEngine_x64.dll \
MicrosoftInstrumentationEngine_DisableCodeSignatureValidation=1 \
MicrosoftInstrumentationEngine_LogLevel=Errors \
MicrosoftInstrumentationEngine_IsPreinstalled=1 \
MicrosoftInstrumentationEngine_RawProfilerHook={71DA0A04-7777-4EC6-9643-7D28B46A8A41} \
MicrosoftInstrumentationEngine_RawProfilerHookPath_64=newrelic\\NewRelic.Profiler.dll \
MicrosoftInstrumentationEngine_RawProfilerHookPath_32=newrelic\\x86\\NewRelic.Profiler.dll \
MicrosoftInstrumentationEngine_FileLogPath=log.txt \
MicrosoftInstrumentationEngine_FileLog="Errors|Dumps" \
NEWRELIC_HOME=newrelic \
NEWRELIC_PROFILER_DELAY_IN_SEC=0 \
console/bin/Debug/net48/console.exe
