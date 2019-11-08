using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 1.0f;
    private float adrenalineBoost = 1.0f;
    private bool adrenaline = false;
    float adrenalineTimer = 0.0f;
    private Rigidbody _rb;
    private Material _material;
    private IEnumerator coroutine;
    static IPlayerState _playerWalkState = new PlayerWalkState();
    static IPlayerState _playerJumpState = new PlayerJumpState();
    private IPlayerState _state = null;
    private bool _onGround = true;

    public float MovementSpeed
    {
        get
        {
            return _movementSpeed;
        }
        set
        {
            _movementSpeed = value;
        }
    }

    public float AdrenalineBoost
    {
        get
        {
            return adrenalineBoost;
        }
        set
        {
            adrenalineBoost = value;
        }
    }

    public static IPlayerState PlayerWalkState
    {
        get
        {
            return _playerWalkState;
        }
    }

    public static IPlayerState PlayerJumpState
    {
        get
        {
            return _playerJumpState;
        }
    }

    public bool OnGround
    {
        get
        {
            return _onGround;
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _material = GetComponent<Renderer>().material;

        _state = _playerWalkState;
        _state.entry(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        coroutine = adrenalineRush();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_onGround);
        IPlayerState state = _state.input();

        if (state == null)
        {
            _state.update();
        }
        else
        {
            _state = state;
            _state.entry(this);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _state.fixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _onGround = true;
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.tag == "Ground")
    //    {
    //        _onGround = true;
    //    }
    //}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _onGround = false;
        }
    }

    public bool getAdrenalineRush()
    {
        return adrenaline;
    }
     public void setAdrenalineRush(bool booly)
    {
        adrenaline = booly;
    }

    IEnumerator adrenalineRush()
    {
        while(true)
        {
            if (adrenaline)
            {
                adrenalineTimer += Time.deltaTime;
                adrenalineBoost = 1.5f;
                _material.SetColor("_Color", Color.red);
            }
            if(adrenalineTimer >= 5.0f)
            {
                adrenaline = false;
                adrenalineBoost = 1;
                adrenalineTimer = 0;
                _material.SetColor("_Color", Color.white);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
