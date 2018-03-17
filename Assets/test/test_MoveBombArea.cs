using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_MoveBombArea : MonoBehaviour {
    public GameObject getTargetBomb()
    {
        if (_List_Bomb.Count <= 0) return null;

        return _List_Bomb[_List_Bomb.Count - 1];
    }

    private List<GameObject> _List_Bomb = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        var renderer = other.GetComponent<Renderer>();
        if (renderer != null) renderer.material.color = Color.blue;
        _List_Bomb.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        var renderer = other.GetComponent<Renderer>();
        if (renderer != null) renderer.material.color = Color.white;
        _List_Bomb.Remove(other.gameObject);
    }
}
