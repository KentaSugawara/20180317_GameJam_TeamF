using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSelectCircle : MonoBehaviour {
    [SerializeField]
    private GameObject _Circle;

    private void Awake()
    {
        _Circle.SetActive(false);
    }

    public void setCircle(bool value)
    {
        if (value && !_Circle.activeInHierarchy)
        {
            _Circle.SetActive(true);
        }
        else if (!value && _Circle.activeInHierarchy)
        {
            _Circle.SetActive(false);
        }
    }
}
