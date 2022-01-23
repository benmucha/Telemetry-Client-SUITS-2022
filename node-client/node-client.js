/** Config data. */
const config = require("./config");

/** Express for the client web application with which the user can be served a webpage to interact with the TestClient. */
const express = require("express");
const app = express();

/** Embedded JavaScript for templating the client page with appropriately configured data. */
const ejs = require("ejs");

/** Module for opening the client page URL. */
const open = require("open");

/** Module for I/O. */
const readline = require("readline");
const readlineInterface = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

const path = require("path");
const http = require("http");

/**
 * URL of the TelemetryServer.
 */
const SERVER_URL = `http://${config.Server.Hostname}:${config.Server.Port}`;
/**
 * URL of the TestClient webapp.
 */
const CLIENT_URL = `http://${config.TestClient.Hostname}:${config.TestClient.Port}`;
/**
 * Relative path to the webapp client directory. This is the directory that hosts the actual frontend that the user interaacts with.
 */
const CLIENT_WEBAPP_DIR = "./webapp-client";

/**
 * Webapp server for serving the webapp client.
 * @type {http.Server}
 */
let webappServer;


function StartClient(){
  ejs.renderFile(path.join(CLIENT_WEBAPP_DIR, "client.ejs"), { SERVER_URL: SERVER_URL, SHORTPOLLING_INTERVAL: config.ShortpollingInterval }, {}, function(err, rendered){
    StartClientApp(rendered);
  });
}

/**
 * Starts the client web application.
 * @param {string} clientPage Raw HTML string of the webapp client page
 */
function StartClientApp(clientPage){
  app.get("/", (_, res) => res.send(clientPage)); // Route the client page to the webapp's root page.
  app.use(express.static(CLIENT_WEBAPP_DIR)); // Route all client webapp files.
  webappServer = app.listen(config.TestClient.Port, OnClientReady); // Bind the configured port and start the webapp server.
}

/**
 * Called when the client is completely ready for user interaction.
 */
function OnClientReady(){
  console.log(`TestClient ready at ${CLIENT_URL}`);
  AwaitUserInput();
  readlineInterface.on("SIGINT", Quit); // Properly quit if user interrupts the node application.
}

/**
 * Prompts for user commands and awaits the user's input.
 */
function AwaitUserInput(){
  readlineInterface.question("Type \"o\" to open the TestClient, or type \"q\" to quit: ", (rawInput) => {
    const input = rawInput.toLowerCase(); // Santized user input.
    switch (input){
      case "open": case "o":
        OpenWebappClient();
        break;
      case "quit": case "q":
        Quit();
        return;
      default:
        OpenWebappClient();
    }
    AwaitUserInput();
  });
}

/**
 * Open the webapp client page in a browser according to the open module.
 */
function OpenWebappClient(){
  open(CLIENT_URL);
}

function Quit(){
  readlineInterface.close();
  webappServer.close(() => process.exit(0));
}


module.exports = { StartClient };