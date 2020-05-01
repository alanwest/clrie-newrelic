#!/bin/bash

# This script assumes you have a local build of the New Relic .NET Agent at $NEWRELIC_HOME

rm -rf newrelic
cp -r "$NEWRELIC_HOME" newrelic
mkdir newrelic/x86
cp "$NEWRELIC_HOME/../_profilerBuild/x64-Debug/NewRelic.Profiler.dll" newrelic
cp "$NEWRELIC_HOME/../_profilerBuild/x86-Release/NewRelic.Profiler.dll" newrelic/x86
rm newrelic/Extensions/NewRelic.Core.Instrumentation.xml
rm newrelic/Extensions/NewRelic.Parsing.Instrumentation.xml
mkdir newrelic/logs
