var config = {};

config.Server = {};
config.Server.Hostname = "localhost";
config.Server.Port = 8080;

config.TestClient = {};
config.TestClient.Hostname = "localhost";
config.TestClient.Port = 8081;

config.ShortPollingInterval = 500; // Short Polling Interval in milliseconds.

module.exports = config;