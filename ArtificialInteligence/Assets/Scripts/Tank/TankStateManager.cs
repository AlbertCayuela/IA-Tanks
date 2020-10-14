using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStateManager : MonoBehaviour
{

    public enum STATE {WANDERING, PATROLING, SEEKING, FLEEING, NULL};
    public STATE current_state = STATE.NULL;

    SteeringWander wander;
    DetectEnemy detect_enemy;
    SeekTarget seek;
    Shoot shoot;

    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponent<SteeringWander>();
        detect_enemy = GetComponent<DetectEnemy>();
        seek = GetComponent<SeekTarget>();
        shoot = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_state == STATE.WANDERING)
            wander.enabled = true;
        else
            wander.enabled = false;

        if (detect_enemy.enemy_detected == true)
        {
            current_state = STATE.SEEKING;
            seek.enabled = true;
            shoot.enabled = true;
        }
        else
            seek.enabled = false;
    }
}
