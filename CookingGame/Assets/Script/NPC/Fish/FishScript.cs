using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    [SerializeField] private Transform handPoint;
    private PatientDataScript patient;
    [SerializeField] private float timeEat;
    private float cooldownEat;
    private bool eatting;
    private Animator animatorFish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Patient" && !eatting)
        {
            patient = other.GetComponent<PatientDataScript>();
            patient.handPoint = handPoint;
            patient.onHand = true;
            EatBanda();
        }
    }
    private void EatBanda()
    {
        cooldownEat = timeEat;
        eatting = true;
        UIManagerScript.dead++;
        Destroy(patient.gameObject, cooldownEat);
    }
    private void Start()
    {
        animatorFish = GetComponent<Animator>();
        cooldownEat = 0;
        eatting = false;
    }
    private void Update()
    {
        if (eatting)
        {
            animatorFish.SetBool("Eatting", true);
            cooldownEat = cooldownEat - Time.deltaTime;
            if (cooldownEat <= 0)
            {
                eatting = false;
                animatorFish.SetBool("Eatting", false);
            }
        }
    }
}
