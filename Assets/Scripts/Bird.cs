using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
    [SerializeField] float _lauchForce = 500;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    private Vector2 _startPosition;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = _rigidBody.position;
        _rigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Change color on mouse down
     private void OnMouseDown()
    {
        _spriteRenderer.color = Color.gray;
    }

     private void OnMouseUp()
    {
        _rigidBody.isKinematic = false;
        var currentPosition = _rigidBody.position;
        var direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidBody.AddForce(direction * _lauchForce);

        _spriteRenderer.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidBody.position = _startPosition;
        _rigidBody.isKinematic = false;
    }


}

