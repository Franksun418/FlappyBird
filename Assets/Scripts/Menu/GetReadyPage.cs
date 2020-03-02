using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class GetReadyPage : MonoBehaviour,IPointerUpHandler,IEventInvoker
{
    Dictionary<EventName, UnityEvent> unityEvents = new Dictionary<EventName, UnityEvent>();

    void Start(){
        unityEvents.Add(EventName.GameStartEvent,new GameStartEvent());
        EventManager.AddInvoker(EventName.GameStartEvent, this);

        EventManager.AddListener(EventName.GameStartEvent, HideMe);
    }

    public void AddListener(EventName eventName,UnityAction unityAction) {
        if (unityEvents.ContainsKey(eventName))
        {
            unityEvents[eventName].AddListener(unityAction);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        unityEvents[EventName.GameStartEvent].Invoke();
    }

    public void HideMe()
    {
        gameObject.SetActive(false);
    }

    public void ShowMe(){
        gameObject.SetActive(false);
    }
}
