# ASCOM.HTTPObservingConditions

A remote weather station plugin for ASCOM

## How does it work?

This plugin performs an HTTP request to your weather station server and
retrieves a JSON object representing the last measurement.

The response is then deserialized into a WeatherData object and exposed to
ASCOM through properties.

So far these sensors are implemented:

- temperature
- humidity

Your JSON response must include a field with the time of the last measurement
because the driver requires it.

## Install

Check out the release section of the repository and download the latest version
installer. Open ASCOM preferences pane and setup the driver with the URL of your
weather station data.

N.B. the URL must start with either http:// or https://, invalid URLs are silently
rejected and a fallback **http://localhost/weather/json** endpoint will be used.

You can check for errors using the *trace log* function.

## Trace logging

A trace log of the driver activities is generated whenever the driver is run.
You can find under Documents > ASCOM > Logs *current date* as a bunch of text files.
