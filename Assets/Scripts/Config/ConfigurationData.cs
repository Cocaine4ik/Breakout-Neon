﻿using System.Collections;
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
    static float minSpawnTime = 5;
    static float maxSpawnTime = 10;

    static int standardBlockPoints = 10;
    static int bonusBlockPoints = 50;
    static int pickupBlockPoints = 25;

    static int ballsPerGame = 5;

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

    // min and max spawn time
    public float MinSpawnTime {
        get { return minSpawnTime; }
    }

    public float MaxSpawnTime {
        get { return maxSpawnTime; }
    }
    // points for standarad block
    public int StandardBlockPoints {
        get { return standardBlockPoints;  }
    }
    // points for bonus block
    public int BonusBlockPoints {
        get { return bonusBlockPoints; }
    }

    // points for pickbup block
    public int PickupBlockPoints {
        get { return pickupBlockPoints; }
    }

    // number of balls per game
    public int BallsPerGame {
        get { return ballsPerGame; }
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
        minSpawnTime = float.Parse(values[3]);
        maxSpawnTime = float.Parse(values[4]);

        standardBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        ballsPerGame = int.Parse(values[8]);
    }
}
