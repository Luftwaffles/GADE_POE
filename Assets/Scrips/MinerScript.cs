using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerScript : MonoBehaviour {

    [SerializeField] private GameObject resourceToUse;
    [SerializeField] private int colectPerTick = 10;
    [SerializeField] private float tickRate = 0.1f;

    private float timeToNextAction = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeToNextAction)
        {
            timeToNextAction += tickRate;
            DelayedUpdate();
        }
    }

    void DelayedUpdate()
    {
        resourceToUse.GetComponent<ResourceScript>().AddResource(colectPerTick, gameObject.tag);
    }
}
