using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour {

    [SerializeField] private string name = "";
    [SerializeField] private int amountLeft = 1000;
    [SerializeField] private int blueTeamAmount = 0;
    [SerializeField] private int redTeamAmount = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(amountLeft < 0)
        {
            amountLeft = 0;
        }
        if (blueTeamAmount < 0)
        {
            blueTeamAmount = 0;
        }
        if (redTeamAmount < 0)
        {
            redTeamAmount = 0;
        }
    }
    
    public int ResourceAmount(string team)
    {
        if (team == "Blue")
        {
            return blueTeamAmount;
        }
        else
        {
            return redTeamAmount;
        }
    }
    
    //This si called when a recorce is mined so anything added here must be removed from the total remaning recorces
    public void AddResource(int amountAdded, string team)
    {
        if (amountLeft > amountAdded)
        {
            if (team == "Blue")
            {
                blueTeamAmount += amountAdded;
            }
            else
            {
                redTeamAmount += amountAdded;
            }
            amountLeft -= amountAdded;
        }
        else
        {
            if (team == "Blue")
            {
                blueTeamAmount += amountLeft;
            }
            else
            {
                redTeamAmount += amountLeft;
            }
            amountLeft = 0;
        }
    }

    public void RemoveResource(int amountRemoved, string team)
    {
        if (team == "Blue")
        {
            blueTeamAmount -= amountRemoved;
        }
        else
        {
            redTeamAmount -= amountRemoved;
        }
    }
}
