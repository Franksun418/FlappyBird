using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    public float timer = 0;
    public float maxTime = 1;

    public float height;

    
    
    // Start is called before the first frame update
    void Start()
    {
            GameObject newPipe = Instantiate(pipePrefab);
            newPipe.transform.position = transform.position+new Vector3(0,Random.Range(-height,height),0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>maxTime)
        {
            GameObject newPipe = Instantiate(pipePrefab);
            newPipe.transform.position = transform.position+new Vector3(0,Random.Range(-height,height),0);
            Destroy(newPipe,15);
            timer=0;
        }

        timer+=Time.deltaTime;
        
    }
}
