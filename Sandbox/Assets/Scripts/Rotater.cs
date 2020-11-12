using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    // Won't be using forces for this, so we can use Update rather than FullUpdate
    void Update()
    {
        // Want this to be smooth, so we use the modifier at the end
        transform.Rotate(new Vector3(0f, 0f, 45f) * Time.deltaTime);
    }
}
