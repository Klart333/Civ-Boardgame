using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartPosition : MonoBehaviour
{
    void Start()
    {
        transform.position += new Vector3(Camera.main.pixelWidth, 0, 0);
    }
}
