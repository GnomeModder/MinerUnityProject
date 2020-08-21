using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineStick : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        string ok = other.gameObject.tag;
        //RoR2.Chat.AddMessage(ok);
        if (other.gameObject.tag != "MineTag")
        {
            BoxCollider box = GetComponent<BoxCollider>();
            box.enabled = false;

            Rigidbody rig = GetComponent<Rigidbody>();
            rig.isKinematic = true;
            rig.useGravity = false;
        }
    }
}