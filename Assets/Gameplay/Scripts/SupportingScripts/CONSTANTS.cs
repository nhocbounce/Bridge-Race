using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONSTANTS
{
    public const float INPUTTHRESHOLD = 300f;
    public const float DIRECTIONCHANGETHRESHOLD = 5f;
    public const float MOVESPEED = 1;
    public const float STACKINGBLOCKTHICKNESS = 0.03f;

    public const int  SEALAYER = 1 << 8;

    public static  Brick GetBrick(Brick brick)
    {
        Brick a;
        a = brick;
        a.transform.localPosition = Vector3.zero;
        return a;
    }
}

public class TAGS
{
    public const string SEATAG = "Sea";
    public const string PLAYERTAG = "Player";
    public const string BOTTAG = "Bot";
    public const string BRICKTAG = "Brick";
}
