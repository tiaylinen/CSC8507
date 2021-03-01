using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public float speedMultiplier;
    public float sizeMultiplier;
    public float powerUpDuration;

    public enum PowerUpType
    {
        Speed,
        Size,
        Freeze
    }

    public PowerUpType power;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(PickUp(collider, power));
        }
    }

    IEnumerator PickUp(Collider player, PowerUpType power)
    {
        ThirdPersonMovement playerfeatures = player.GetComponent<ThirdPersonMovement>();
      
        //positive
        if (power == PowerUpType.Speed)
        {
            playerfeatures.speed *= speedMultiplier;

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(powerUpDuration);

            playerfeatures.speed /= speedMultiplier;
        }

        //positive
        if (power == PowerUpType.Size)
        {
            player.transform.localScale *= sizeMultiplier;

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(powerUpDuration);

            player.transform.localScale /= sizeMultiplier;
        }

        //negative
        if (power == PowerUpType.Freeze)
        {
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            playerRb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(powerUpDuration);

            playerRb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        Destroy(gameObject);

    }


}
