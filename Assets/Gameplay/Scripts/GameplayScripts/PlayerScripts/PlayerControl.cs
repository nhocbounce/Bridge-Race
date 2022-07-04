using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Touch touch;

    [SerializeField]
    GameObject player;

    public static Vector3 curDir;


    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.sqrMagnitude > CONSTANTS.INPUTTHRESHOLD)
                {
                    player.transform.eulerAngles = GetMoveDir(touch);
                }
            }
            player.transform.Translate(Vector3.forward * CONSTANTS.MOVESPEED * Time.deltaTime);
        }

    }

    Vector3 GetMoveDir(Touch touch)
    {
        float angle = Vector2.SignedAngle(Vector2.up, touch.deltaPosition);
        Vector3 moveDir = new Vector3(0, -angle, 0);
        return moveDir;
    }
}
