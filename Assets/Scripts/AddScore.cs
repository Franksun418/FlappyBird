using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddScore : MonoBehaviour,IIntEventInvoker
{
    [SerializeField]
    private int point = 0;

    Dictionary<EventName,UnityEvent<int>> unityIntEvents = new Dictionary<EventName, UnityEvent<int>>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        unityIntEvents[EventName.AddPointIntEvent].Invoke(point);
    }
    // Start is called before the first frame update
    void Start()
    {
        unityIntEvents.Add(EventName.AddPointIntEvent, new AddPointIntEvent());
        EventManager.AddInvoker(EventName.AddPointIntEvent,this);
    }

    public void AddListener(EventName eventName,UnityAction<int> unityAction){
        if(unityIntEvents.ContainsKey(eventName))
        {
            unityIntEvents[eventName].AddListener(unityAction);
        }

    }

}
