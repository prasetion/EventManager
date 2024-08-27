using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager<TEventArgs>
{

    private static Dictionary<string, Action<TEventArgs>> eventList = new Dictionary<string, Action<TEventArgs>>();

    public static void RegisterEvent(string eventName, Action<TEventArgs> eventHandler)
    {
        if (!eventList.ContainsKey(eventName))
        {
            eventList[eventName] = eventHandler;
        }
        else
        {
            eventList[eventName] += eventHandler;
        }
    }

    public static void UnregisterEvent(string eventName, Action<TEventArgs> eventHandler)
    {
        if (eventList.ContainsKey(eventName))
        {
            eventList[eventName] -= eventHandler;
        }
    }

    public static void TriggerEvent(string eventName, TEventArgs eventArgs)
    {
        if (eventList.ContainsKey(eventName))
        {
            eventList[eventName]?.Invoke(eventArgs);
        }
    }
}
