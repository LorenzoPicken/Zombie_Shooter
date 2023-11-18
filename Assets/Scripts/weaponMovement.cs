using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponMovement : MonoBehaviour
{
    [SerializeField] CharacterController mover;
    [SerializeField] Rigidbody rb;
    public bool sway, swayRotation, bobOffset, bobSway;

    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;

    private WeaponRecoil recoil;


    void Start()
    {
        initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation;
        recoil = GetComponent<WeaponRecoil>();
    }
    // Update is called once per frame
    void Update()
    {
        if (recoil.isRecoiling == false)
        {
            GetInput();
            Sway();
            SwayRotation();
            BobOffset();
            BobRotation();

            CompositePositionRotation();

        }
    }

    #region Input
    Vector2 walkInput;
    Vector2 lookInput;

    void GetInput()
    {
        walkInput.x = Input.GetAxis("Horizontal");
        walkInput.y = Input.GetAxis("Vertical");
        walkInput = walkInput.normalized;

        lookInput.x = Input.GetAxis("Mouse X");
        lookInput.y = Input.GetAxis("Mouse Y");
    }
    #endregion


    #region Sway
    public float step = 0.01f;
    public float maxStepDistance = 0.06f;
    Vector3 swayPos;

    void Sway()
    {
        if (sway == false) { swayPos = Vector3.zero; return; }

        Vector3 invertLook = lookInput * -step;
        invertLook.x = Mathf.Clamp(invertLook.x, -maxStepDistance, maxStepDistance);
        invertLook.y = Mathf.Clamp(invertLook.y, -maxStepDistance, maxStepDistance);

        swayPos = invertLook;
    }

    #endregion

    #region Sway Rotation

    public float rotationStep = 4f;
    public float maxRotationStep = 5f;
    Vector3 swayEulerRot;
    void SwayRotation()
    {
        if (swayRotation == false){ swayEulerRot = Vector3.zero;return; }
        {
            Vector2 invertLook = lookInput * -rotationStep;
            invertLook.x = Mathf.Clamp(invertLook.x, -maxRotationStep, maxRotationStep);
            invertLook.y = Mathf.Clamp(invertLook.y, -maxRotationStep, maxRotationStep);
            swayEulerRot = new Vector3(invertLook.y, invertLook.x, invertLook.x);

        }
    }
    #endregion


    #region Bob Offset

    public float speedCurve;

    float curveSin { get => Mathf.Sin(speedCurve); }
    float curveCos { get => Mathf.Cos(speedCurve); }

    public Vector3 travelLimit = Vector3.one * 0.025f;
    public Vector3 bobLimit = Vector3.one * 0.01f;

    Vector3 bobPosition;

    void BobOffset()
    {
        speedCurve += Time.deltaTime * (mover.isGrounded? rb.velocity.magnitude : 1f) + 0.0f;

        if(bobOffset == false) { bobPosition = Vector3.zero; return; }

        bobPosition.x =
            (curveCos * bobLimit.x * (mover.isGrounded ? 1 : 0))
            - (walkInput.x * travelLimit.x);

        bobPosition.y = 
            (curveSin * bobLimit.y)
            -(rb.velocity.y * travelLimit.y);

        bobPosition.z =
            -(walkInput.y * travelLimit.z);

    }
    #endregion


    #region Bob Rotation

    public Vector3 multiplier;
    Vector3 bobEulerRotation;

    void BobRotation()
    {
        if (bobSway == false) { bobEulerRotation = Vector3.zero; return; }

        bobEulerRotation.x = (walkInput != Vector2.zero ? multiplier.x * (Mathf.Sin(2 * speedCurve)) :
            multiplier.x * (Mathf.Sin(2 * speedCurve) / 2));

        bobEulerRotation.y = (walkInput != Vector2.zero ? multiplier.y * curveCos : 0);
        bobEulerRotation.z = (walkInput != Vector2.zero ? multiplier.z * curveCos * walkInput.x : 0);
    }

    #endregion


    #region Composite Position Rotation

    float smooth = 10f;
    float smoothRot = 12f;
    void CompositePositionRotation()
    {

        //position
        /*transform.localPosition = Vector3.Lerp(initialLocalPosition,
            swayPos + bobPosition,
            Time.deltaTime * smooth);

        //rotation
        Quaternion finalRotation = Quaternion.Euler(swayEulerRot) * Quaternion.Euler(bobEulerRotation);
        transform.localRotation = Quaternion.Slerp(initialLocalRotation,
            Quaternion.Euler(swayEulerRot) * Quaternion.Euler(bobEulerRotation),
            Time.deltaTime * smoothRot);*/

        transform.localPosition = Vector3.Lerp(initialLocalPosition,
        initialLocalPosition + swayPos + bobPosition,
        Time.deltaTime * smooth);

        // rotation
        Quaternion finalRotation = Quaternion.Euler(swayEulerRot) * Quaternion.Euler(bobEulerRotation);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            finalRotation,
            Time.deltaTime * smoothRot);
    }
    #endregion
}
