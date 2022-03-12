using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class TelemetryReader
{
    private readonly int _shortPollInterval;
    private readonly ApiClient _apiClient;
    private CancellationTokenSource _pollingCancellationSource;

    public delegate void ReceiveData(RoomSimulationStateData simulationStateRoom);
    public event ReceiveData OnReceiveData;
    
    public delegate void ApiError(Exception exception);
    public event ApiError OnApiError;
    
    public event ApiClient.GetRequestLog OnGetRequest
    {
        add => _apiClient.OnGetRequest += value;
        remove => _apiClient.OnGetRequest -= value;
    }
    public event ApiClient.PostRequestLog OnPostRequest
    {
        add => _apiClient.OnPostRequest += value;
        remove => _apiClient.OnPostRequest -= value;
    }
    
    public TelemetryReader(string hostname, int port, int shortPollInterval)
    {
        _shortPollInterval = shortPollInterval;
        this._apiClient = new ApiClient(hostname, port);
    }
    
    //private static int ShortPollDelayMilliseconds(int tickRate) => (int)(1f / tickRate * 1000);
    
    /// <summary>
    /// Starts reading from the API.
    /// </summary>
    /// <exception cref="Exception"></exception>
    public void StartReading()
    {
        if (_pollingCancellationSource != null)
        {
            throw new Exception("Stop this first !!");
            return;
        }
        
        _pollingCancellationSource = new CancellationTokenSource();
        ShortPollLoop(); // TaskCreationOptions.LongRunning
    }

    /// <summary>
    /// Polling loop for continuously polling data from the API.
    /// </summary>
    private async void ShortPollLoop()
    {
        CancellationToken cancellationToken = _pollingCancellationSource.Token;
        while (!cancellationToken.IsCancellationRequested)
            await Task.WhenAll(PollSimulationStateStep(), Task.Delay(_shortPollInterval, cancellationToken));
    }

    private async Task PollSimulationStateStep()
    {
        try
        {
            var simulationState = await _apiClient.GetObject<List<RoomSimulationStateData>>("simulationstate");
            OnReceiveData?.Invoke(simulationState.First());
        }
        catch (Exception e)
        {
            OnApiError?.Invoke(e);
        }
    }

    public void StopReading()
    {
        _pollingCancellationSource.Cancel();
        _pollingCancellationSource = null;
    }
}
