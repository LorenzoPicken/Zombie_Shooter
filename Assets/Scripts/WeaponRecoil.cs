using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [SerializeField] private Transform gunTransform;
    [SerializeField] private Vector3 recoilDirection = new Vector3(0.0f, 0.1f, -0.2f);
    [SerializeField] private float recoilDuration = 0.1f;
    [SerializeField] private float smoothTime = 0.1f;

    public bool isRecoiling = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private Vector3 recoilVelocity = Vector3.zero;

    private void Start()
    {
        initialPosition = gunTransform.localPosition;
        targetPosition = initialPosition;
    }

    public void ApplyRecoil()
    {
        if (!isRecoiling)
        {
            isRecoiling = true;
            targetPosition = initialPosition + recoilDirection;
            InvokeRepeating("RecoilAnimation", 0f, Time.fixedDeltaTime);
            Invoke("ResetRecoil", recoilDuration);
        }
    }

    private void RecoilAnimation()
    {
        gunTransform.localPosition = Vector3.SmoothDamp(gunTransform.localPosition, targetPosition, ref recoilVelocity, smoothTime);
    }

    private void ResetRecoil()
    {
        isRecoiling = false;
        CancelInvoke("RecoilAnimation");
        gunTransform.localPosition = initialPosition;
    }

}
