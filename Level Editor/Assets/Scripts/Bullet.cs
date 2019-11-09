using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int _damage = 50;
    //[SerializeField]
    //private int _force = 10;
    private bool _active = false;
    private float _lifeTime = 2.0f;
    private float _currTime = 0.0f;

    public bool Active
    {
        get
        {
            return _active;
        }
        set
        {
            _active = value;
        }
    }

    public float CurrTime
    {
        get
        {
            return _currTime;
        }
        set
        {
            _currTime = value;
        }
    }

    private void Update()
    {
        if (_active)
        {
            _currTime += Time.deltaTime;

            if (_currTime >= _lifeTime)
                BulletPool.Instance.reclaim(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (_active)
        {
            GameObject obj = collision.gameObject;


            if (obj.tag == "Enemy")
            {
                ContactPoint contactPoint = collision.GetContact(0);

                //Vector3 force = -contactPoint.normal * _force;
                //collision.rigidbody.AddForceAtPosition(force, contactPoint.point);

                collision.gameObject.GetComponent<Health>().HP -= _damage;

                BulletPool.Instance.reclaim(gameObject);
            }
            if (obj.tag == "Target1")
            {
                obj.SetActive(false);
            }
            if (obj.tag == "Target2")
            {
                obj.SetActive(false);
            }
        }
    }
}
