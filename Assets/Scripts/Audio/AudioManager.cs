﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager {

    #region Fields

    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    #endregion

    #region Properties

    // Gets whether or not the audio manager has been initialized
    public static bool Initialized {
        get { return initialized; }
    }

    #endregion

    #region Methods

    // Initializes the audio manager
    public static void Initialize(AudioSource source) {

        initialized = true;
        audioSource = source;

        audioClips.Add(AudioClipName.BallCollision,
            Resources.Load<AudioClip>("Audio/BallCollision"));
        audioClips.Add(AudioClipName.FreezeEffect,
            Resources.Load<AudioClip>("Audio/FreezeEffect"));
        audioClips.Add(AudioClipName.GameOver,
            Resources.Load<AudioClip>("Audio/GameOver"));
        audioClips.Add(AudioClipName.MenuButtonClick,
             Resources.Load<AudioClip>("Audio/MenuButtonClick"));
        audioClips.Add(AudioClipName.MenuMusic,
             Resources.Load<AudioClip>("Audio/MenuMusic"));
        audioClips.Add(AudioClipName.SpeedUpEffect,
              Resources.Load<AudioClip>("Audio/SpeedUpEffect"));
        audioClips.Add(AudioClipName.BallReduced,
              Resources.Load<AudioClip>("Audio/BallReduced"));
    }

    // Plays the audio clip with the given name
    public static void Play(AudioClipName name) {

        audioSource.PlayOneShot(audioClips[name]);

    }

    public static void Play(AudioClipName name, float volume) {

        audioSource.PlayOneShot(audioClips[name], volume);

    }
    // Stop playing current clip
    public static void Stop() {

        audioSource.Stop();
    }

    // return true if audio clip is plaing
    public static bool IsPlaying() {

        Debug.Log(audioSource.isPlaying);

        return audioSource.isPlaying;
    }
    #endregion

}
