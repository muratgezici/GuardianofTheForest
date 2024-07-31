using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGhost : CEnemy
{
    public static event Action<bool> EnemyDied;
}
