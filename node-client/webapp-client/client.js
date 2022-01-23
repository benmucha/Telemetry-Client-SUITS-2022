
/**
 * @constant
 * @typedef {Object} Config
 * @global
 */
const CONFIG = {
  /** 
   * Base URL of the telemetry server
   * @property 
   * @type {string}
  */
  SERVER_URL: null,
  /** 
   * The interval in milliseconds at which to short poll the API for simulation data
   * @property 
   * @type {number}
  */
  SHORTPOLLING_INTERVAL: null
}


/**
 * Entry point for the client which takes necessary configuration constants.
 * @param {string} Templated_SERVER_URL 
 * @param {number} Templated_SHORTPOLLING_INTERVAL 
 */
function StartClient(Templated_CONFIG){
  CONFIG.SERVER_URL = Templated_CONFIG.SERVER_URL;
  CONFIG.SHORTPOLLING_INTERVAL = Templated_CONFIG.SHORTPOLLING_INTERVAL;
  PollSimulationStepLoop();
}

/**
 * Recurrently polls the SimulationState from the server and updates the page visuals accordingly.
 */
function PollSimulationStepLoop(){
  Get("simulationstate").then(simulationState => {
    $("#simulationstepText").text(JSON.stringify(simulationState, null, 2));
    setTimeout(PollSimulationStepLoop, CONFIG.SHORTPOLLING_INTERVAL);
  });
}


/**
 * Starts the server. (This should be called only once per server)
 */
 function StartServer(){
  // Add a room.
  Post("rooms", {
    name: "MyRoomName"
  });
  
  // Add a user.
  Post("users", {
    username: "MyUsername",
    room: 1
  });
  
  // Add the simulation.
  var simData = {
    room: 1
  };
  Post("simulationcontrol", simData);
  Post("simulationfailure", simData);
  Post("simulationstate", simData);
  Post("simulationstateuia", simData);
  Post("simulationuia", simData);

  // Start the simulation for room 1.
  Get("simulationcontrol/sim/1/start");
}