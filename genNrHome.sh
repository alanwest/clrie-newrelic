#!/bin/bash

# This script assumes you have a local build of the New Relic .NET Agent at $NEWRELIC_HOME

rm -rf newrelic
cp -r "$NEWRELIC_HOME" newrelic
mkdir newrelic/x86
if [ -d "$NEWRELIC_HOME/../_profilerBuild/x64-Debug" ]
then
    configuration="Debug"
else
    configuration="Release"
fi

cp "$NEWRELIC_HOME/../_profilerBuild/x64-$configuration/NewRelic.Profiler.dll" newrelic
cp "$NEWRELIC_HOME/../_profilerBuild/x86-$configuration/NewRelic.Profiler.dll" newrelic/x86

if [ "$configuration" == "Debug" ]
then
    cp "$NEWRELIC_HOME/../_profilerBuild/x64-$configuration/NewRelic.Profiler.pdb" newrelic
    cp "$NEWRELIC_HOME/../_profilerBuild/x86-$configuration/NewRelic.Profiler.pdb" newrelic/x86
fi

mkdir newrelic/logs
