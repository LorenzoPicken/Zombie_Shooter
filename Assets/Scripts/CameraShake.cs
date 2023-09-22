using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 1f;
    public AnimationCurve curve;
    public bool start = false;

    private void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(CameraShaking());
        }
    }

    public IEnumerator CameraShaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float shakeStrength = curve.Evaluate(elapsedTime / shakeDuration);
            transform.position = startPosition + Random.insideUnitSphere * shakeStrength;
            yield return null;
        }
        transform.position = new Vector3 ();
    }
}
