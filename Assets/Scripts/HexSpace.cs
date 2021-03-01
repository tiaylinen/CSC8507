using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSpace : MonoBehaviour {

    public float timer;
    public bool triggered;

    private void Update()
    {
        if (triggered == true)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            triggered = true;
        }
    }
}
