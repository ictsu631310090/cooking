using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyCheck : MonoBehaviour
{
    [HideInInspector] public bool haveArmy;
    [HideInInspector] public float timeCooldown;
    [HideInInspector] public float timeCooldownMax;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Army")
        {
            timeCooldown = timeCooldownMax;
            Destroy(other.gameObject);
        }
    }
    private void Start()
    {
        haveArmy = true;
        timeCooldownMax = timeCooldown;
    }
    private void Update()
    {
        if (haveArmy)
        {
            timeCooldown -= Time.deltaTime;
            if (timeCooldown <= 0)
            {
                haveArmy = false;
                timeCooldown = timeCooldownMax;
            }
        }
    }
}
