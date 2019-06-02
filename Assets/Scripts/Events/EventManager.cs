using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Event : UnityEvent<System.Object, System.Object> { }

public class EventManager : MonoBehaviour {

    // create new dictionary with events and their names on string
    private Dictionary <EventName, Event> eventDictionary;

    public static EventManager Instance;

    private void Awake() {
        if(Instance == null) {

            Instance = this;
            eventDictionary = new Dictionary<EventName, Event>();
        }
        else if (Instance != this) {

            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
    // add listener to dictionary
    public static void StartListening(EventName eventName, UnityAction <System.Object, System.Object> listener) {

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
    // delete listener from the dictionary
    public static void StopListening(EventName eventName, UnityAction <System.Object, System.Object> listener) {

        if (Instance == null) return;
        Event thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.RemoveListener(listener);
        }
    }
    // invoke event from the dictionary
    public static void TriggerEvent(EventName eventName, System.Object arg0 = null, System.Object arg1 = null) {

        Event thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.Invoke(arg0, arg1);
        }
    }
}
