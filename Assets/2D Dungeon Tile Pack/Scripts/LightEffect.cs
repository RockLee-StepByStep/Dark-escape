using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    Light lightSource;
    float lightIntencity;
    [SerializeField]
    private float minIntencity = 3f, maxIntencity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        lightIntencity = Random.Range(minIntencity, maxIntencity);
        lightSource.intensity = lightIntencity;
    }
}
