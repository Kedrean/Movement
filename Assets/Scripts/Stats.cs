using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mob"))
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}
