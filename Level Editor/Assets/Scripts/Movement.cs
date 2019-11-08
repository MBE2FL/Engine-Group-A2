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

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _material = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        coroutine = adrenalineRush();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move with WASD
        //if (Input.GetKey(KeyCode.W))
        //    transform.position += transform.forward * _movementSpeed;
        //else if (Input.GetKey(KeyCode.S))
        //    transform.position -= transform.forward * _movementSpeed;
        //else if (Input.GetKey(KeyCode.A))
        //    transform.position -= transform.right * _movementSpeed;
        //else if (Input.GetKey(KeyCode.D))
        //    transform.position += transform.right * _movementSpeed;

        if (Input.GetKey(KeyCode.W))
            _rb.AddForce(transform.forward * _movementSpeed * adrenalineBoost);
        if (Input.GetKey(KeyCode.S))
            _rb.AddForce(-transform.forward * _movementSpeed * adrenalineBoost);
        if (Input.GetKey(KeyCode.A))
            _rb.AddForce(-transform.right * _movementSpeed * adrenalineBoost);
        if (Input.GetKey(KeyCode.D))
            _rb.AddForce(transform.right * _movementSpeed * adrenalineBoost);
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
