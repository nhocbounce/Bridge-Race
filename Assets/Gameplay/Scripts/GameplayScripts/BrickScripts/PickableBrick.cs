using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBrick : Brick
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(CONSTANTS.PLAYERTAG) || collision.gameObject.CompareTag(CONSTANTS.BOTTAG))
        {
            transform.SetParent(collision.transform);
        }
    }
}
