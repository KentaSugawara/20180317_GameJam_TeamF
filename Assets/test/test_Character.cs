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

    [SerializeField]
    private Animator _Animator;

    [SerializeField]
    private SpriteRenderer _SpriteRender;

    [SerializeField]
    private test_isGrounded _isGrounded;

    private bool _isRun;

    private int hash_isRun = Animator.StringToHash("isRun");
    private int hash_isLeft = Animator.StringToHash("isLeft");

    // Use this for initialization
    void Start () {
        _isRun = false;
        StartCoroutine(Routine_Main());
	}
	
    private IEnumerator Routine_Main()
    {
        while (true)
        {
            var pos = transform.position;
            float h = Input.GetAxisRaw(_InputName_MoveH);
            pos.x += h * _MoveSpeed * Time.deltaTime;
            Debug.Log(h);
            if (h < -0.1f)
            {
                _isRun = true;
                _Animator.SetBool(hash_isRun, true);
                _Animator.SetBool(hash_isLeft, true);
                _SpriteRender.flipX = true;
            }
            else if (h > 0.1f)
            {
                _isRun = true;
                _Animator.SetBool(hash_isRun, true);
                _Animator.SetBool(hash_isLeft, false);
                _SpriteRender.flipX = false;
            }
            else
            {
                _isRun = true;
                _Animator.SetBool(hash_isRun, false);
            }

            if (_isGrounded.isGrounded && Input.GetButtonDown(_InputName_Jump))
            {
                _Rigidbody.AddForce(Vector3.up * _JumpPower, ForceMode.Impulse);
            }

            _Rigidbody.position = pos;
            yield return null;
        }
    }
}
