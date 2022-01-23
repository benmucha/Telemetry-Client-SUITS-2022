
/**
 * Sends an HTTP GET request to the server.
 * @param {string} apiAddress Relative API address
 * @returns Response JSON payload
 */
function Get(apiAddress){
  return ApiReq("GET", apiAddress);
}
/**
 * Sends an HTTP POST request to the server.
 * @param {string} apiAddress Relative API address
 * @param {Object} data JSON data to send in the POST body
 * @returns Response JSON payload
 */
function Post(apiAddress, data){
  return ApiReq("POST", apiAddress, data);
}

/**
 * Sends an API request.
 * @param {string} method HTTP method
 * @param {string} apiAddress Relative API address
 * @param {Object} [data] JSON data to send (for respective methods)
 * @returns Response JSON payload promise
 */
function ApiReq(method, apiAddress, data = null){
  const url = GetApiPath(apiAddress);
  let consolelogArgs = [`%c${method} %c${url}`, "color:orange;", null];
  if (data != null)
    consolelogArgs.push("\n", data);
  console.log.apply(null, consolelogArgs);
  switch (method){
    case "GET":
      return axios.get(url).then(r => r.data).catch(error => ApiError(error));
    case "POST":
      return axios.post(url, data).then(r => r.data).catch(error => ApiError(error));
  }
}

/**
 * Signals that an error occured in calling the API.
 * @param {string} errorMsg Internal error message
 */
function ApiError(errorMsg){
  console.error("API Error: " + errorMsg);
}

/**
 * Transforms relative API URI address to URL.
 * @param {string} apiAddress Relative API resource address
 * @returns 
 */
function GetApiPath(apiAddress){
  return CONFIG.SERVER_URL + "/api/" + apiAddress;
}