using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputHandler inputHandler;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    public static PlayerMovement instance;
    private Rigidbody rb;

    public bool isWalking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        HandlePlayerMovement();
    }
    public void HandleJump()
    {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }
    private void HandlePlayerMovement()
    {
        Vector2 inputDirector = inputHandler.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputDirector.x, 0, inputDirector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        isWalking = moveDirection != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);


    }
}
