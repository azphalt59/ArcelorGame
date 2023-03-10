using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    [SerializeField] private GameObject target;
    Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        target = PlayerInventory.Instance.gameObject;
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
            transform.position = target.transform.position + offset;
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }
    public void NullTarget()
    {
        target = null;
    }
}
