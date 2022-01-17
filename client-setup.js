const config = require("./config");
const express = require("express");
const app = express();
const ejs = require("ejs");
const bodyParser = require("body-parser");
const jsonParser = bodyParser.json();

const { StartServer } = require("./server-setup");

const serverUrl = `http://${config.Server.Hostname}:${config.Server.Port}`;
const clientUrl = `http://${config.TestClient.Hostname}:${config.TestClient.Port}`;


function StartClient(){
  ejs.renderFile("./client/client.ejs", { serverUrl: serverUrl, interval: config.ShortPollingInterval }, {}, function(err, rendered){
    StartClientApp(rendered);
  });
}

function StartClientApp(clientPage){
  app.get("/", (req, res) => {
    res.send(clientPage);
  });
  app.use(express.static("client"));

  app.post("/command", jsonParser, (req, res) => {
    var command = req.body.command;
    console.log("Commanded: " + command);
    switch (command){
      case "StartServer":
        StartServer();
        break;
    }
    res.send("command executed successfully");
  })
  
  app.listen(config.TestClient.Port, () => {
    console.log(`TestClient ready at ${clientUrl}`)
  })
}


module.exports = { StartClient };