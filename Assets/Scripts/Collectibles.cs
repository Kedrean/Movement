using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public bool isCoins, isBoost;
    public float boostAmt = 5f; // Boost multiplier
    public float boostDur = 5f; // Boost duration
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movement playerScript = other.GetComponent<Movement>();
            if (isCoins)
            {
                playerScript.score++;
                Destroy(gameObject);
            }
            if (isBoost)
            {
                playerScript.ApplyBoost(boostAmt, boostDur);
                Destroy(gameObject);
            }
        }
    }
}
