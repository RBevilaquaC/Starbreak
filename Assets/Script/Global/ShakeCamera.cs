using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private bool start = false;
    private float shakeCameraDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < shakeCameraDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }

        transform.position = startPosition;
    }
}
