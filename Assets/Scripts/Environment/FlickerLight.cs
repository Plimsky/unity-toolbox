using System.Collections;
using UnityEngine;

namespace Environment
{
    public class FlickerLight : MonoBehaviour
    {
        public Light LightToFlicker;
        public float MinWaitTime;
        public float MaxWaitTime;

        // Use this for initialization
        void Start()
        {
            LightToFlicker = GetComponent<Light>();
            StartCoroutine(Flashing());
        }

        IEnumerator Flashing()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(MinWaitTime, MaxWaitTime));
                LightToFlicker.enabled = !LightToFlicker.enabled;
            }
        }
    }
}