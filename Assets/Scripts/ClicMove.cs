using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ClicMove : MonoBehaviour
{
    public float _speed;
    private Vector3 _tPosition;
    private bool _isMoving;

    void Start()
    {

    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal == 0 && vertical == 0)
        {
            if (Input.GetMouseButton(0))
                TriggerPozition();
            
            if (_isMoving)
                ItsMove();
        }
        else
        {
            Vector2 position = transform.position;
            position.x = position.x + horizontal * _speed * Time.deltaTime;
            position.y = position.y + vertical * _speed * Time.deltaTime;
            transform.position = position;
            _isMoving = false;
        }
    }
    void TriggerPozition()
    {
        _tPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _tPosition.z = transform.position.z;
        _isMoving = true;
    }

    void ItsMove()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _tPosition);
        transform.position = Vector3.MoveTowards(transform.position, _tPosition, _speed * Time.deltaTime);

        if (transform.position == _tPosition)
        {
            _isMoving = false;
        }
    }
}
