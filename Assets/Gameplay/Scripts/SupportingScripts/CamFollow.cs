using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Vector3 offset, initPos;
    public static CamFollow Instance;
    // Update is called once per frame

    private void Start()
    {
        Instance = this;
        initPos = transform.position;
        GetOffset();
    }
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find(TAGS.PLAYERTAG);
            GetOffset();
        }
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position - offset;
    }

    void GetOffset()
    {
        offset = player.transform.position - transform.position;
    }

    public void ResetCamPos()
    {
        transform.position = initPos;
        GetOffset();
    }
}
