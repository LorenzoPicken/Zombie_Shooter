using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    //Movement Values
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpForce = 7f;
    public float gravity = 10f;
    public bool isRunning;
    float curSpeedX, curSpeedY;

    //Looking Values
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    //Stamina
    [SerializeField] private float maxStamina;
    [SerializeField] private float staminaDrainRate;
    [SerializeField] private float staminaRegenRate;
    [SerializeField] private float timeBeforeStandardRegen;
    [SerializeField] private float timeBeforeExhaustionRegen;
    private float currentTimeBeforeStandardRegen, currentTimeBeforeExhaustionRegen;
    private float currentStamina;
    private Coroutine regenRoutine;
    public static event Action OnStaminaExhaustion;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public GunBehaviour gunBehaviour;

    public bool canMove = true;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentStamina = maxStamina;
        currentTimeBeforeStandardRegen = timeBeforeStandardRegen;
        currentTimeBeforeExhaustionRegen = timeBeforeExhaustionRegen;

    }

    // Update is called once per frame
    void Update()
    {

        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 vertical;
        Vector3 horizontal;

       /* //Move Forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            vertical = new Vector3(0, 0, 1);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            vertical = new Vector3(0, 0, 0);
        }

        //Move Backwards
        if (Input.GetKeyDown(KeyCode.S))
        {
            vertical = new Vector3(0, 0, -1);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            vertical = new Vector3(0, 0, 0);
        }

        //Move Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontal = new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            horizontal = new Vector3(0, 0, 0);
        }

        //Move Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontal = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            horizontal = new Vector3(0, 0, 0);
        }*/

        isRunning = (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && currentStamina > 0);
        if (isRunning && canMove)
        {
            curSpeedX = runSpeed * Input.GetAxis("Vertical");
            curSpeedY = runSpeed * Input.GetAxis("Horizontal");
            currentTimeBeforeStandardRegen = timeBeforeStandardRegen;
            currentTimeBeforeExhaustionRegen = timeBeforeExhaustionRegen;
            currentStamina -= staminaDrainRate * Time.deltaTime;
            if (regenRoutine != null)
            {
                StopCoroutine(regenRoutine);
                regenRoutine = null;
            }
            Debug.Log("Stamina Levels " + currentStamina);


        }
        else if (!isRunning && canMove)
        {
            curSpeedX = walkSpeed * Input.GetAxis("Vertical");
            curSpeedY = walkSpeed * Input.GetAxis("Horizontal");
            if (currentStamina < maxStamina && currentStamina > 0)
            {
                currentTimeBeforeStandardRegen -= Time.deltaTime;
                if (currentTimeBeforeStandardRegen <= 0)
                {
                    if (regenRoutine == null)
                    {
                        regenRoutine = StartCoroutine(StamRegen());

                    }
                }
            }
            else if (currentStamina <= 0)
            {
                Debug.Log("Stamina is Depleated");
                RegenFromExhaustion();
            }

        }


        //float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        // float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);



        #endregion

        #region Handles Jumping

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpForce;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        #endregion


        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);


        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        #endregion
    }
    public void RegenFromExhaustion()
    {
        currentTimeBeforeExhaustionRegen -= Time.deltaTime;
        if (currentTimeBeforeExhaustionRegen <= 0)
        {
            if (regenRoutine == null)
            {
                currentStamina = maxStamina / 2;
                regenRoutine = StartCoroutine(StamRegen());
                OnStaminaExhaustion?.Invoke();
            }
        }
    }

    IEnumerator StamRegen()
    {
        while (currentStamina < maxStamina)
        {
            Debug.Log("StandardStaminaRegen has Begun" + currentStamina);
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            yield return null;
        }
    }
}