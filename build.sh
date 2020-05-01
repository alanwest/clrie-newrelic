#!/bin/bash
[ -d "GeneratedAssemblies" ] && rm -rf GeneratedAssemblies
[ -f "log.txt" ] && rm log.txt
[ ! -d "newrelic/logs" ] && mkdir newrelic/logs
dotnet build console
