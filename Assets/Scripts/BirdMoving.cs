using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdMoving : MonoBehaviour,IEventInvoker
{
    public GameManager gameManager;

    Rigidbody2D rgbd2d;

    public float velocity;

    public float gravityScaleDuringGame = 0.6f;

    Dictionary<EventName, UnityEvent> unityEvents = new Dictionary<EventName, UnityEvent>();
    
    // Start is called before the first frame update
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        rgbd2d.gravityScale = 0;

        unityEvents.Add(EventName.GameOverEvent,new GameOverEvent());
        EventManager.AddInvoker(EventName.GameOverEvent,this);

        EventManager.AddListener(EventName.GameStartEvent,ActivateBirdMoving);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameStarted)
        {
            if(Input.GetMouseButtonDown(0))
        {
            rgbd2d.velocity = Vector2.up* velocity;
        }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        unityEvents[EventName.GameOverEvent].Invoke();
    }

    public void ActivateBirdMoving(){
        rgbd2d.gravityScale = gravityScaleDuringGame;
         rgbd2d.velocity = Vector2.up* velocity;
    }

    public void AddListener(EventName eventName,UnityAction unityAction) {
        if (unityEvents.ContainsKey(eventName))
        {
            unityEvents[eventName].AddListener(unityAction);
        }
    }
}
