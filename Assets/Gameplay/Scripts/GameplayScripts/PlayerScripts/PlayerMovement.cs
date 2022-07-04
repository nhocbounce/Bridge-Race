using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 lastPos;
    private void Update()
    {
        lastPos = transform.position;
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag(CONSTANTS.SEATAG))
                transform.position = lastPos;
        }
    }
}
