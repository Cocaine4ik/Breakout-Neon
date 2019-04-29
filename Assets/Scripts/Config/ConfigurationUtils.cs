﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils {
    public static ConfigurationData configurationData;
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifetime {
        get { return configurationData.BallLifetime; }
    }

    #endregion
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize() {
        configurationData = new ConfigurationData();
    }
}
