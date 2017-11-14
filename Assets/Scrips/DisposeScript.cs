using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposeScript : MonoBehaviour {
    [SerializeField] private float timeToDispose = 5f;

    // Use this for initialization
    void Start () {
        timeToDispose = Time.time + timeToDispose;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeToDispose)
        {
            Destroy(gameObject);
        }
    }
}
