using System.Collections;
using UnityEngine;

namespace System.Utils
{
    public class CameraShake : MonoBehaviour
    {
        public float Frequency = 10f;

        public IEnumerator Shake(float duration, float magnitude)
        {
            Vector3 originPosition = transform.localPosition;
            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                Vector2 perlinVector2 = PerlinShake(magnitude);

                transform.localPosition = new Vector3(perlinVector2.x, perlinVector2.y, originPosition.z);
                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originPosition;
        }

        public Vector2 PerlinShake(float magnitude)
        {
            Vector2 result;
            float seed = Time.time * Frequency;
            result.x = Mathf.Clamp01(Mathf.PerlinNoise(seed, 0f)) - 0.5f;
            result.y = Mathf.Clamp01(Mathf.PerlinNoise(0f, seed)) - 0.5f;
            result = result * magnitude;
            return result;
        }
    }
}