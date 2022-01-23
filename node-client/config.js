const config = module.exports = {};

/**
 * TelemetryServer address data.
 */
config.Server = {};
config.Server.Hostname = "localhost";
config.Server.Port = 8080;

/**
 * TestClient webapp address data.
 */
config.TestClient = {};
config.TestClient.Hostname = "localhost";
config.TestClient.Port = 8081;

/**
 * Interval for simulation state short polling in milliseconds.
 */
config.ShortpollingInterval = 1000;