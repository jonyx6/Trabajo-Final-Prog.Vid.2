using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ataque : ScriptableObject
{
    public abstract IEnumerator AtacarI(GameObject objetivo, GameObject atacante);
}
