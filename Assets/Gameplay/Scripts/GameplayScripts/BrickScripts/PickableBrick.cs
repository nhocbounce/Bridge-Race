using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBrick : Brick
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAGS.PLAYERTAG) || collision.gameObject.CompareTag(TAGS.BOTTAG))
        {
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
