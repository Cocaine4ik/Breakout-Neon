using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Event : UnityEvent<System.Object> { }

public class EventManager : MonoBehaviour {

    // create new dictionart with events and theor names on string
    private Dictionary <string, Event> eventDictionary;

    public static EventManager Instance;

    private void Awake() {
        if(Instance == null) {

            Instance = this;
            eventDictionary = new Dictionary<string, Event>();
        }
        else if (Instance != this) {

            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void StartListening(string eventName, UnityAction <System.Object> listener) {

        Event thisEvent = null;
        if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new Event();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction <System.Object> listener) {

        if (Instance = null) return;
        Event thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, System.Object arg = null) {

        Event thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.Invoke(arg);
        }
    }
}
