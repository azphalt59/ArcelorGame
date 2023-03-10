using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject tpPosition;
    
    public void TeleportPlayer()
    {
        PlayerInventory.Instance.gameObject.transform.position = tpPosition.transform.position;
        CameraFollow.Instance.SetTarget(tpPosition);
    }

}
