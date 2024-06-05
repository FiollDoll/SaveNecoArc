using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "kill")
        {
            GameObject.Find("scripts").GetComponent<lvl>().PointAdd();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().UpdateHP();
            Destroy(this.gameObject);
        }
    }
}
