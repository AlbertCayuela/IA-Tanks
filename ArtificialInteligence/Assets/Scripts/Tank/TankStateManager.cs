using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStateManager : MonoBehaviour
{
    public bool is_patrol_tank = false;
    public bool is_wander_tank = false;

    public enum STATE {WANDERING, PATROLING, SEEKING, FLEEING, NULL};
    public STATE current_state = STATE.NULL;

    SteeringWander wander;
    Flee flee;
    SeekTarget seek;
    Shoot shoot;
    PatrolAgent patrol;

    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponent<SteeringWander>();
        seek = GetComponent<SeekTarget>();
        shoot = GetComponent<Shoot>();
        patrol = GetComponent<PatrolAgent>();
        flee = GetComponent<Flee>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_state == STATE.WANDERING)
        {
            wander.enabled = true;
        }
            
        //else if (current_state != STATE.WANDERING)
            //wander.enabled = false;

        if (current_state == STATE.PATROLING)
        {
            patrol.enabled = true;
            //Debug.Log("STATE PATROLING");
        }   
        //else if (current_state != STATE.PATROLING)
           // patrol.enabled = false;

        if (current_state == STATE.SEEKING)
            seek.enabled = true;
        //else if (current_state != STATE.SEEKING)
            //seek.enabled = false;

        if (current_state == STATE.FLEEING)
            flee.enabled = true;
        //else if (current_state != STATE.FLEEING)
            //flee.enabled = false;

        EnemyIsDetected();
      
    }

    //CHECK IF ENEMY IS DETECTED AND ON WHAT TYPE OF TANK IS THE SCRIPT ACTING
    void EnemyIsDetected()
    {
        if (shoot.enemy_detected && is_patrol_tank)
        {
            current_state = STATE.SEEKING;
        }

        if (shoot.enemy_detected && is_wander_tank)
        {
            current_state = STATE.FLEEING;
        }
    }

    void DisableScripts()
    {
        wander.enabled = false;
        patrol.enabled = false;
        seek.enabled = false;
        flee.enabled = false;
    }
}

