using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sph_Child : MonoBehaviour
{
    public MishenColLVL0 parent;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "laser")
        {
            parent.sph_cnt++;
            gameObject.SetActive(false);
        }
    }
}
