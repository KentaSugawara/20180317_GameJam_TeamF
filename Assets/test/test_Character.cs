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
    private string _InputName_MoveBomb;

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

    [SerializeField]
    private test_FieldManager _FieldManager;

    [SerializeField]
    private float _BombMoveDelaySeconds = 1.0f;

    [SerializeField]
    private test_MoveBombArea _BombArea;

    [SerializeField]
    private bool _isField1 = true;

    private bool _isRun;
    private bool _inBombMoveDelay = false;

    private int hash_isRun = Animator.StringToHash("isRun");
    private int hash_isLeft = Animator.StringToHash("isLeft");

    // Use this for initialization
    void Start () {
        var joysticks = Input.GetJoystickNames();
        foreach (var j in joysticks)
        {
            Debug.Log(j);
        }
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
            //Debug.Log(h);
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
                Debug.Log(_InputName_Jump);
                _Rigidbody.AddForce(Vector3.up * _JumpPower, ForceMode.Impulse);
            }

            if (!_inBombMoveDelay)
            {
                if (Input.GetButtonDown(_InputName_MoveBomb))
                {
                    var target = _BombArea.getTargetBomb();
                    if (target != null)
                    {
                        Debug.Log("Move!");
                        _FieldManager.MoveObject(target.transform, _isField1);
                        StartCoroutine(Routine_Delay());
                    }
                }
            }

            _Rigidbody.position = pos;
            yield return null;
        }
    }

    private IEnumerator Routine_Delay()
    {
        _inBombMoveDelay = true;
        for (float t = 0.0f; t < _BombMoveDelaySeconds; t += Time.deltaTime)
        {
            yield return null;
        }
        _inBombMoveDelay = false;
    }

    [SerializeField]
    private LifeManager _LifeManager;

    public void Damage(int value)
    {
        _LifeManager.PlayerDamageOn();
    }
}
