using System;
using UnityEngine;

public class TelemetryClientBasic : MonoBehaviour
{
    private TelemetryReader _telemetryReader;

    // Start is called before the first frame update
    void Start()
    {
        StartReader(Config.LoadConfig());
    }

    /// <summary>
    /// Starts reading simulation state data.
    /// </summary>
    /// <param name="config"></param>
    private void StartReader(Config config)
    {
        //Debug.Log(config.ServerHostname);
        _telemetryReader = new TelemetryReader(config.ServerHostname, config.ServerPort, config.ShortpollingInterval);
        _telemetryReader.OnReceiveData += OnOnReceiveData;
        _telemetryReader.OnApiError += OnApiError;
        _telemetryReader.OnGetRequest += OnApiGetRequest;
        _telemetryReader.StartReading();
    }

    /// <summary>
    /// Callback for receiving data.
    /// </summary>
    /// <param name="simulationStateRoom"></param>
    private static void OnOnReceiveData(RoomSimulationStateData simulationStateRoom)
    {
        Debug.Log($"output: {simulationStateRoom.ID} - {simulationStateRoom.WaterTimeLeft}");
    }
    
    private static void OnApiError(Exception e)
    {
        Debug.LogException(e);
    }
    
    private void OnApiGetRequest(string method, string url)
    {
        Debug.Log($"<color=orange>{method}</color> <color=default>{url}</color>");
    }

    /// <summary>
    /// Stops reading data.
    /// </summary>
    private void StopReader()
    {
        if (_telemetryReader is null) 
            return;
        
        _telemetryReader.OnReceiveData -= OnOnReceiveData;
        _telemetryReader.OnApiError -= OnApiError;
        _telemetryReader.StopReading();
    }
    
    
    private void OnDestroy()
    {
        StopReader();
    }
}