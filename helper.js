const http = require("http");
const config = require("./config");

function GetApiPath(apiAddress){
  return "/api/" + apiAddress;
}

function HttpReq(reqType, apiAddress, data){
  const options = {
    hostname: config.Server.Hostname,
    port: config.Server.Port,
    path: GetApiPath(apiAddress),
    method: reqType,
  }
  if (data != null){
    options.headers = {
      "Content-Type": "application/json",
      "Content-Length": data.length
    };
  }
  
  const req = http.request(options, res => {
    console.log(`(${reqType}) ${apiAddress}: ${res.statusCode}`);
  })
  
  req.on("error", error => {
    console.error(error);
  })
  
  if (data != null){
    req.write(data);
  }
  req.end();
}

function Post(apiAddress, data){
  HttpReq("POST", apiAddress, data);
}
function Get(apiAddress){
  HttpReq("GET", apiAddress, null);
}


module.exports = { Get, Post };