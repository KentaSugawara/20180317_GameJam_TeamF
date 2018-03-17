using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_isGrounded : MonoBehaviour {

    [SerializeField]
    private bool _isGrounded;
    public bool isGrounded
    {
        get { return _isGrounded; }
    }


    private int ColliderCount;
    private void OnTriggerEnter(Collider other)
    {
        _isGrounded = true;
        ++ColliderCount;
    }

    private void OnTriggerExit(Collider other)
    {
        --ColliderCount;
        if (ColliderCount <= 0)
        {
            _isGrounded = false;
        }
    }
}
