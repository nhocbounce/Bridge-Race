using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Touch touch;

    [SerializeField]
    GameObject player;

    public float thresholdTest;

    public static Vector3 curDir;

    private void Start()
    {
        
    }

    void Update()
    {
        float speed = CONSTANTS.MOVESPEED;
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.sqrMagnitude > CONSTANTS.INPUTTHRESHOLD)
                {
                    curDir  = GetMoveDir(touch);
                }
            }

            if (touch.phase == TouchPhase.Ended)
                speed = 0;


            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }

    private void LateUpdate()
    {
        player.transform.eulerAngles = curDir;
    }


    Vector3 GetMoveDir(Touch touch)
    {
        float angle = Vector2.SignedAngle(Vector2.up, touch.deltaPosition);
        angle = SmoothenRotate(angle);
        Vector3 moveDir = new Vector3(0, -angle, 0);
        return moveDir;
    }

    float SmoothenRotate(float angle)
    {
        float curAngle = player.transform.eulerAngles.y;
        float deltaAngle = Mathf.Abs(GetTrueAngle(angle) - GetTrueAngle(curAngle));
        if (deltaAngle > thresholdTest)
            return angle;
        else
            return curAngle;
    }

    float GetTrueAngle(float angle)
    {
        if (angle < 0)
            angle = 360 + angle;
        return angle;
    }
}
