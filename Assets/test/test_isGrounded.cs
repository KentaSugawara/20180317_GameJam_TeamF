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

    private void Update()
    {
        if (Colliders.Count <= 0)
        {
            _isGrounded = false;
        }
    }

    private int ColliderCount;
    private List<Collider> Colliders = new List<Collider>();
    private void OnTriggerEnter(Collider other)
    {
        if (!Colliders.Contains(other))
        {
            Colliders.Add(other);
            _isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //--ColliderCount;
        //if (ColliderCount <= 0)
        //{
        //    _isGrounded = false;
        //}
        //_isGrounded = false;
        Colliders.Remove(other);
        if (Colliders.Count <= 0)
        {
            _isGrounded = false;
        }
    }
}
