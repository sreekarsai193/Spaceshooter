using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingTop;
    void Start()
    {
       InitBounds();
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    void Move()
    {
        Vector3 delta = rawInput*moveSpeed*Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x=Mathf.Clamp(transform.position.x+delta.x, minBounds.x+paddingLeft,maxBounds.x-paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y+delta.y, minBounds.y+paddingBottom, maxBounds.y-paddingTop);
        transform.position = newPos ;
    }
}
