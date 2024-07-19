using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Orientation")]
    public Transform orientation;

    #region Public Fields:
    [Header("Movement")]
    public float moveSpeed;

    [Header("Jump")]
    public float JumpHeight;
    #endregion

    float horizInput;
    float vertInput;

    Vector3 moveDirect;

    Rigidbody rb;

    CharacterController characterController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        KeyInputs(); 
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    public void KeyInputs()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    }

    public void MovePlayer()
    {
        moveDirect = orientation.forward * vertInput + orientation.right * horizInput;
        rb.AddForce(moveDirect.normalized * moveSpeed * 4f, ForceMode.Force);
        //characterController.Move(moveDirect * moveSpeed * Time.deltaTime);

    }


}
