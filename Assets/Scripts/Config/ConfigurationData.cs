using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// A container for the configuration data
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 400;
    static float ballLifetime = 10;

    #endregion

    #region Properties

    // gets the paddle move units per second
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    // gets the ball impulse force
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    // gets the ball lifetime in seconds
    public float BallLifetime {
        get { return ballLifetime; }
    }

    #endregion

    #region Constructor

    public ConfigurationData()
    {
        StreamReader input = null;

        try {
            // open and read ConfigurationData.csv file from Streaming assets folder
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            // write fieled names to a variable
            string names = input.ReadLine();

            // write field values to a variable
            string values = input.ReadLine();

            // use values from csv to set values in game
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
    // parse values and set ConfigurationData fields
    void SetConfigurationDataFields (string csvValues) {

        string[] values = csvValues.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifetime = float.Parse(values[2]);

    }
}
