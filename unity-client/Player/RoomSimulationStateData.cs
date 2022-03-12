using System;
using Newtonsoft.Json;

public class UserTest
{
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("room")]
    public int Room { get; set; }
}


/// <summary>
/// <see cref="RoomSimulationStateData"/> from deserialized JSON.
/// </summary>
public class RoomSimulationStateData
{
    [JsonProperty("id")]
    public int ID { get; set; }
    
    [JsonProperty("room")]
    public int Room { get; set; }
    
    [JsonProperty("isRunning")]
    public bool IsRunning { get; set; }
    
    [JsonProperty("isPaused")]
    public bool IsPaused { get; set; }
    
    /// <summary>
    /// Duration of the current EVA. EVA Time is displayed in the format “hh:mm:ss”
    /// </summary>
    [JsonProperty("time")]
    public float EVATime { get; set; }
    
    [JsonProperty("timer")]
    public string Timer { get; set; }
    
    [JsonProperty("started_at")]
    public string StartedAt { get; set; }
    
    /// <summary>
    /// Heart rate of the astronaut measured in beats per minute. Expected range is from 80 to 100 bpm.
    /// </summary>
    [JsonProperty("heart_bpm")]
    public int HeartRate { get; set; }
    
    /// <summary>
    /// External Environment pressure. Expected range is from 2 to 4 psia.
    /// </summary>
    [JsonProperty("p_sub")]
    public float SubPressure { get; set; }
    
    /// <summary>
    /// The pressure inside the spacesuit needs to stay within certain limits. If the suit pressure gets too high, or if the pressure exceeds nominal limits, the movement of the astronaut will be heavily reduced. Expected range is from 2 to 4 psid.
    /// </summary>
    [JsonProperty("p_suit")]
    public float SuitPressure { get; set; }
    
    [JsonProperty("t_sub")]
    public float SubTime { get; set; }
    
    /// <summary>
    /// Speed of the cooling fan. Expected range is from 10,000 to 40,000 RPM.
    /// </summary>
    [JsonProperty("v_fan")]
    public int FanTachometer { get; set; }
    
    /// <summary>
    /// Pressure inside the Primary Oxygen Pack. Expected range is from 750 to 950 psia.
    /// </summary>
    [JsonProperty("p_o2")]
    public float OxygenPressure { get; set; }
    
    /// <summary>
    /// Flowrate of the Primary Oxygen Pack. Expected range is from 0.5 to 1 psi/min.
    /// </summary>
    [JsonProperty("rate_o2")]
    public float OxygenRate { get; set; }
    
    [JsonProperty("batteryPercent")]
    public float BatteryPercent { get; set; }
    
    /// <summary>
    /// Total capacity of the spacesuit’s battery. Expected range is from 0 to 30 amp-hr.
    /// </summary>
    [JsonProperty("cap_battery")]
    public float BatteryCapacity { get; set; }
    
    [JsonProperty("battery_out")]
    public float BatteryOut { get; set; }
    
    /// <summary>
    /// Gas pressure from H2O system. Expected range is from 14 to 16 psia.
    /// </summary>
    [JsonProperty("p_h2o_g")]
    public float H2OGasPressure { get; set; }
    
    /// <summary>
    /// Liquid pressure from H2O system. Expected range is from 14 to 16 psia.
    /// </summary>
    [JsonProperty("p_h2o_l")]
    public float H2OLiquidPressure { get; set; }
    
    /// <summary>
    /// Flowrate of the Secondary Oxygen Pack. Expected range is from 0.5 to 1 psi/min.
    /// </summary>
    [JsonProperty("rate_sop")]
    public float SOPRate { get; set; }
    
    /// <summary>
    /// The remaining time until the battery of the spacesuit is completely discharged. Battery life is usually displayed in the format “hh:mm:ss” Expected range is from 0 to 10 hours.
    /// </summary>
    [JsonProperty("t_battery")]
    public string BatteryTimeLeft { get; set; }

    [JsonProperty("t_oxygenPrimary")]
    public int OxygenPrimaryTimeLeft { get; set; }
    
    [JsonProperty("t_oxygenSec")]
    public float OxygenSecondaryTimeLeft { get; set; }
    
    /// <summary>
    /// Percentage left in the primary oxygen supply.
    /// </summary>
    [JsonProperty("ox_primary")]
    public float PrimaryOxygen { get; set; }
    
    /// <summary>
    /// Percentage left in the secondary oxygen supply.
    /// </summary>
    [JsonProperty("ox_secondary")]
    public float SecondaryOxygen { get; set; }
    
    /// <summary>
    /// The remaining time until the available oxygen is depleted. Time life oxygen is usually displayed in the format “hh:mm:ss” Expected range is from 0 to 10 hours.
    /// </summary>
    [JsonProperty("t_oxygen")]
    public string OxygenTimeLeft { get; set; }
    
    [JsonProperty("cap_water")]
    public float WaterCapacity { get; set; }
    
    /// <summary>
    /// The remaining time until the water resources of the spacesuit are depleted. Time life water is usually displayed in the format “hh:mm:ss” Expected range is from 0 to 10 hours.
    /// </summary>
    [JsonProperty("t_water")]
    public string WaterTimeLeft { get; set; }
    
    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [JsonProperty("updatedAt")]
    public DateTimeOffset UpdatedAt { get; set; }
}