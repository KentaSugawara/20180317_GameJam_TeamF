using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Character : MonoBehaviour {
    [SerializeField]
    private string _InputName_MoveH;

    [SerializeField]
    private string _InputName_MoveV;

    [SerializeField]
    private string _InputName_Jump;

    [SerializeField]
    private float _MoveSpeed;

    [SerializeField]
    private float _JumpPower;

    [SerializeField]
    private Rigidbody _Rigidbody;


    // Use this for initialization
    void Start () {
        StartCoroutine(Routine_Main());
	}
	
    private IEnumerator Routine_Main()
    {
        while (true)
        {
            var pos = transform.position;
            //Debug.Log(Input.GetAxisRaw(_InputName_MoveH));
            pos.x += Input.GetAxisRaw(_InputName_MoveH) * _MoveSpeed * Time.deltaTime;

            if (Input.GetButtonDown(_InputName_Jump))
            {
                _Rigidbody.AddForce(Vector3.up * _JumpPower, ForceMode.Impulse);
            }

            _Rigidbody.position = pos;
            yield return null;
        }
    }
}
