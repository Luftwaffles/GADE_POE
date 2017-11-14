using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitScript : MonoBehaviour {

    [SerializeField] private string name = "";
    [SerializeField] private string team = "Blue";
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 10;
    [SerializeField] private int speed = 1;
    [SerializeField] private int range = 1;
    [SerializeField] private int cost = 100;
    [SerializeField] private float tickRate = 0.2f;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject explosionParticles;

    private int currentHealth = 100;

    private GameObject target;

    private string enemyTag = "Red";

    private NavMeshAgent navAgent;

    private float timeToNextAction = 0.0f;

    //Dirty but easy to read system
    private string state = "targeting";


    // Use this for initialization
    void Start () {
        currentHealth = health;
        gameObject.tag = team;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = true;
        if(team == "Blue")
        {
            enemyTag = "Red";
        }
        else
        {
            enemyTag = "Blue";
        }

        //Ensures that units will never lock to the default game object
        target = new GameObject();
        target.transform.position = new Vector3(999, 999, 999);
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.transform.localScale = new Vector3(currentHealth/100f ,0.1f ,0.1f);

        if (Time.time > timeToNextAction + Random.Range(-0.001f, 0.001f))
        {
            timeToNextAction += tickRate;
            DelayedUpdate();
        }
    }

    void DelayedUpdate()
    {
        if (currentHealth < (health / 100 * 25))
        {
            if (currentHealth <= 0)
            {
                Instantiate(explosionParticles, transform.position, transform.rotation);
                explosionParticles.name = "Boom";
                Destroy(gameObject);
            }
            else
            {
                state = "retreating";
            }
        }
        else if (FindEnemy() == true)
        {
            if (Vector3.Distance(target.transform.position, transform.position) > range)
            {
                state = "targeting";

                navAgent.SetDestination(target.transform.position);

                transform.LookAt(target.transform.position);
            }
            else
            {
                state = "fighting";
            }
        }
        else
        {
            state = "idle";
        }

        State();
    }

    //Helps set the "state" of the unit but also sets the nearest target
    bool FindEnemy()
    {
        bool found = false;
        GameObject [] enemys = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject en in enemys)
        {
            //99% chance this will kill you ################
            found = true;
            
            if (target == null)
            {
                target = en;
            }
            
                if (Vector3.Distance(transform.position, en.transform.position) < Vector3.Distance(transform.position, target.transform.position) && en != GetComponent<GameObject>())
                {
                    target = en;
                }

        }
        return found;
    }

    void Fight()
    {
            Debug.Log("PURGE PURGE PURGE");
            target.GetComponent<UnitScript>().TakeDamage(damage);
    }

    void State()
    {
        if (state == "retreating")
        {
            Debug.Log("RUN AWAY! RUN AWAY!");
            RunToRandom();
        }
        else if(state == "idle")
        {
            Debug.Log("Not doing anything");
        }
        else if(state == "targeting")
        {
            Debug.Log("Hunting!");
        }
        else if (state == "fighting")
        {
                Fight();
        }
    }

    //Running in a random direction if helth below 25%. I would make them run away from the enemy but if they did, all of the units coudl ends up runing away from eachother and never ending the game
    void RunToRandom()
    {
        //Select a new destination if you have reached your current one
        if (Vector3.Distance(transform.position, navAgent.destination) < 2)
        {
            Debug.Log("Been there done that");
            navAgent.SetDestination(new Vector3(Random.Range(-9.0f, 9.0f), 0, Random.Range(-9.0f, 9.0f)));
        }
    }

    //Public methods

    public void TakeDamage(int enemyDamage)
    {
        currentHealth -= enemyDamage;
    }

    public int GetCost()
    {
        return cost;
    }
}
