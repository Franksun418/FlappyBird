using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverPage : MonoBehaviour,IEventInvoker
{
    [SerializeField]
    Text highestScore;

    [SerializeField]
    Text currentScore;

    Dictionary<EventName,UnityEvent> unityEvents = new Dictionary<EventName, UnityEvent>();

    void Start(){
        unityEvents.Add(EventName.GameRestartEvent,new GameRestartEvent());
        EventManager.AddInvoker(EventName.GameRestartEvent,this);

        currentScore.text = GameManager.score.ToString();
        highestScore.text = PlayerPrefs.GetInt("HighestScore").ToString();
    }

    public void HandleRestartButtonOnClickEvent(){
        unityEvents[EventName.GameRestartEvent].Invoke();
    }

    public void AddListener(EventName eventName, UnityAction unityAction){
        if(unityEvents.ContainsKey(eventName))
        {
            unityEvents[eventName].AddListener(unityAction);
        }
    }

}
