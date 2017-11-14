using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProductionScript : MonoBehaviour {
    [SerializeField] private GameObject unitToProduce;
    [SerializeField] private float tickRate = 3f;
    [SerializeField] private GameObject resourceToUse;

    private ResourceScript resourceScript;
    private int unitCost = 0;

    private float timeToNextAction = 0.0f;
    // Use this for initialization
    void Start ()
    {
        resourceScript = resourceToUse.GetComponent<ResourceScript>();
        unitCost = unitToProduce.GetComponent<UnitScript>().GetCost();
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.time > timeToNextAction)
        {
            timeToNextAction += tickRate;
            DelayedUpdate();
        }
	}

    void DelayedUpdate()
    {
        if(resourceScript.ResourceAmount(gameObject.tag) >= unitCost)
        {
            Instantiate(unitToProduce, transform.position, transform.rotation);
            resourceScript.RemoveResource(unitCost, gameObject.tag);
        }
    }
}
