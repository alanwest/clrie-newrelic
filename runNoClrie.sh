#!/bin/bash
COR_ENABLE_PROFILING=1 \
COR_PROFILER={71DA0A04-7777-4EC6-9643-7D28B46A8A41} \
COR_PROFILER_PATH_32=newrelic\\x86\\NewRelic.Profiler.dll \
COR_PROFILER_PATH_64=newrelic\\NewRelic.Profiler.dll \
NEWRELIC_HOME=newrelic \
NEWRELIC_PROFILER_DELAY_IN_SEC=0 \
console/bin/Debug/net48/console.exe
