using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelControl : MonoBehaviour
{

    [SerializeField]
    Transform brickPool;
    [SerializeField]
    GameObject stackBrick;

    Stack<GameObject> brickStack = new Stack<GameObject>();

    Vector3 lastPos;
    private void Update()
    {
        lastPos = transform.position;
    }

    private void LateUpdate()
    {
        //Prevent from falling out of floor
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag(TAGS.SEATAG))
            {
                transform.position = lastPos;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.transform.tag;
        switch (tag)
        {
            case TAGS.BOTTAG:
                break;
            case TAGS.BRICKTAG:
                GameObject go;
                go = Instantiate(stackBrick, StackPos(), Quaternion.identity,brickPool);
                brickStack.Push(go);
                break;
        }
    }

    Vector3 StackPos()
    {
        Vector3 v3 = transform.position + new Vector3(0, brickStack.Count * CONSTANTS.STACKINGBLOCKTHICKNESS, 0);
        return v3;
    }
}
