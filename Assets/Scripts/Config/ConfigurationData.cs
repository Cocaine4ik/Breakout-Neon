using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// A container for the configuration data
/// 
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 0.5f;
    static float ballImpulseForce = 400;

    #endregion

    #region Properties

    /// Gets the paddle move units per second
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    #endregion

    #region Constructor

    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    public ConfigurationData()
    {
        StreamReader input = null;

        try {

            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string names = input.ReadLine();

            string values = input.ReadLine();
            Debug.Log("SetConfigurationDataFields..." + values);
            SetConfigurationDataFields(values);

        }
        catch(Exception e) {
            
        }
        finally {
            if (input != null) {
                input.Close();
            }
        }
        
    }

    #endregion

    void SetConfigurationDataFields (string csvValues) {
        string[] values = csvValues.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);

    }
}
