using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour,IDamageble
{
    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        Debug.Log("Коробка");
        return true;
    }

 
}
