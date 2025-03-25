using System.Collections;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    [Range(0f, 9f)] public float movementSpeed = 5;
    [Tooltip("Time in seconds to change")] public float duration = 2f;
        
    private void Update()
    {
        for (float num = 0; num <= 9; num++)
        {
            if (Input.GetKeyDown(num.ToString()))
            {
                StartGlide(num);
            }
        }
    }
    private void StartGlide(float targetValue)
    {
        StartCoroutine(GlideToTarget(targetValue));
    }

    private IEnumerator GlideToTarget(float targetValue)
    {
        float startValue = movementSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            movementSpeed = Mathf.Lerp(startValue, targetValue, elapsedTime / duration);
            yield return null; // advance one frame
        }
        movementSpeed = targetValue; // Ensure exact target value at the end
    }
}
