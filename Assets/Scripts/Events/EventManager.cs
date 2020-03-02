using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public static class EventManager
{
    static Dictionary<EventName, List<UnityAction>> listeners = new Dictionary<EventName, List<UnityAction>>();
    static Dictionary<EventName, List<IEventInvoker>> invokers = new Dictionary<EventName, List<IEventInvoker>>();

    static Dictionary<EventName, List<UnityAction<int>>> intListeners = new Dictionary<EventName, List<UnityAction<int>>>();
    static Dictionary<EventName, List<IIntEventInvoker>> intInvokers = new Dictionary<EventName, List<IIntEventInvoker>>();


    public static void Initialize()
    {

        foreach (EventName eventName in Enum.GetValues(typeof(EventName)))
        {
            switch (eventName)
            {
                case EventName.GameOverEvent:
                case EventName.GameStartEvent:
                case EventName.GameRestartEvent:
                    {
                        if (!invokers.ContainsKey(eventName))
                        {
                            invokers.Add(eventName, new List<IEventInvoker>());
                            listeners.Add(eventName, new List<UnityAction>());
                        }
                        else
                        {
                            invokers[eventName].Clear();
                            listeners[eventName].Clear();
                        }
                    }
                    break;
                case EventName.AddPointIntEvent:
                {
                        if (!intInvokers.ContainsKey(eventName))
                        {
                            intInvokers.Add(eventName, new List<IIntEventInvoker>());
                            intListeners.Add(eventName, new List<UnityAction<int>>());
                        }
                        else
                        {
                            intInvokers[eventName].Clear();
                            intListeners[eventName].Clear();
                        }
                }
                break;
            }
        }
    }

    public static void AddInvoker(EventName eventName, IEventInvoker invoker)
    {
        foreach (UnityAction listener in listeners[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        invokers[eventName].Add(invoker);
    }

    public static void AddListener(EventName eventName, UnityAction listener)
    {
        foreach (IEventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        listeners[eventName].Add(listener);

    }

    public static void AddInvoker(EventName eventName, IIntEventInvoker intInvoker)
    {
        foreach (UnityAction<int> intListener in intListeners[eventName])
        {
            intInvoker.AddListener(eventName, intListener);
        }
        intInvokers[eventName].Add(intInvoker);
    }

    public static void AddListener(EventName eventName, UnityAction<int> intListener)
    {
        foreach (IIntEventInvoker intInvoker in intInvokers[eventName])
        {
            intInvoker.AddListener(eventName, intListener);
        }
        intListeners[eventName].Add(intListener);

    }


    public static void RemoveInvoker(EventName eventName, IEventInvoker eventInvoker)
    {
        invokers[eventName].Remove(eventInvoker);
    }

    public static void RemoveListener(EventName eventName, UnityAction eventListener)
    {
        listeners[eventName].Remove(eventListener);
    }

    public static void RemoveInvoker(EventName eventName, IIntEventInvoker intEventInvoker)
    {
        intInvokers[eventName].Remove(intEventInvoker);
    }

    public static void RemoveListener(EventName eventName, UnityAction<int> eventListener)
    {
        intListeners[eventName].Remove(eventListener);
    }

}
