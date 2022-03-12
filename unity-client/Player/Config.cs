
using System;
using System.IO;
using System.Xml;
using UnityEngine;

public class Config
{
    public string ServerHostname { get; }
    public int ServerPort { get; }

    public int ShortpollingInterval { get; }

    public const string ConfigFileName = "TelemetryClientConfig.xml";

    public Config(string configFilePath)
    {
        XmlDocument doc;
        try
        {
            Debug.Log("Loading config at: " + configFilePath);
            doc = new XmlDocument();
            doc.Load(configFilePath);
        }
        catch (Exception)
        {
            throw new Exception("Config file not found. Config file needs to be located at: " + configFilePath);
        }
        
        try
        {
            ServerHostname = GetNodeText("server/hostname");
            ServerPort = int.Parse(GetNodeText("server/port"));
            ShortpollingInterval = int.Parse(GetNodeText("shortpollingInterval"));
            string GetNodeText(string node) => doc.DocumentElement.SelectSingleNode(node).InnerText;
        }
        catch (Exception e)
        {
            Debug.LogError("Config loading failed (potentially invalid config values): " + e);
            throw e;
        }
    }
    public static Config LoadConfig()
    {
        return new Config(Path.Combine(Application.streamingAssetsPath, ConfigFileName));
    }
}
