const { Get, Post } = require("./helper");

function StartServer(){
  const newRoom = JSON.stringify({
    name: "MyRoomName"
  })
  Post("rooms", newRoom);
  
  const newUser = JSON.stringify({
    username: "MyUsername",
    room: 1
  })
  Post("users", newUser);
  
  
  var simData = JSON.stringify({
    room: 1
  });
  
  Post("simulationcontrol", simData);
  Post("simulationfailure", simData);
  Post("simulationstate", simData);
  Post("simulationstateuia", simData);
  Post("simulationuia", simData);

  Get("simulationcontrol/sim/1/start");
}

module.exports = { StartServer };