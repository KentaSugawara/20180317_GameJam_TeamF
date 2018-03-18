using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_MoveBombArea : MonoBehaviour {
    public List<CreateEffect> getTargetBomb()
    {
        //if (_List_Bomb.Count <= 0) return null;

        return  _List_Bomb;// _List_Bomb[_List_Bomb.Count - 1];
    }

    private List<CreateEffect> _List_Bomb = new List<CreateEffect>();
    private void OnTriggerEnter(Collider other)
    {
        //var renderer = other.GetComponent<Renderer>();
        //if (renderer != null) renderer.material.color = Color.blue;
        var circle = other.GetComponentInChildren<BombSelectCircle>();
        if (circle != null) circle.setCircle(true);
        var effect = other.GetComponentInChildren<CreateEffect>();
        if (effect != null) _List_Bomb.Add(effect);
    }

    private void OnTriggerExit(Collider other)
    {
        //var renderer = other.GetComponent<Renderer>();
        //if (renderer != null) renderer.material.color = Color.white;
        var circle = other.GetComponentInChildren<BombSelectCircle>();
        if (circle != null) circle.setCircle(false);
        var effect = other.GetComponentInChildren<CreateEffect>();
        if (effect != null) _List_Bomb.Remove(effect);
    }
}
