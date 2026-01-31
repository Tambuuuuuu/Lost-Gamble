using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventsType
{
    StartCardGame,
    PlayerWon,
    ActiveTrick
}
public class EventManager : MonoBehaviour
{
    public delegate void MethodToSubscribe(params object[] parameters);

    static Dictionary<EventsType, MethodToSubscribe> _events;

    public static void SubscribeToEvent(EventsType eventType, MethodToSubscribe methodToSubscribe)
    {

        if (_events == null) _events = new Dictionary<EventsType, MethodToSubscribe>();

        _events.TryAdd(eventType, null);
        _events[eventType] += methodToSubscribe;
    }

    public static void UnsubscribeToEvent(EventsType eventType, MethodToSubscribe methodToUnsubscribe)
    {
        if (_events == null) return;

        if (!_events.ContainsKey(eventType)) return;

        _events[eventType] -= methodToUnsubscribe;
    }

    public static void TriggerEvent(EventsType eventType, params object[] parameters)
    {
        if (_events == null) return;

        if (!_events.ContainsKey(eventType)) return;

        if (_events[eventType] == null) return;

        _events[eventType](parameters);
    }
}
