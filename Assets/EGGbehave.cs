using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGGbehave : MonoBehaviour
{
    public float EggSpeed = 40;
    // Start is called before the first frame update
    void Start()
    {
        GMbehave.TheScrip.EggChange(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += EggSpeed * Time.smoothDeltaTime * transform.up;

        if (!GMbehave.TheScrip.isInBound(transform.localPosition))
        {
            Destroy(transform.gameObject);
            GMbehave.TheScrip.EggChange(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PLbehave>() != null || (collision.gameObject.GetComponent<Pointbehave>() != null && collision.gameObject.GetComponent<Pointbehave>().isVisiable))
        {
            Destroy(transform.gameObject);
            GMbehave.TheScrip.EggChange(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PLbehave>() != null || (collision.gameObject.GetComponent<Pointbehave>() != null && collision.gameObject.GetComponent<Pointbehave>().isVisiable))
        {
            Destroy(transform.gameObject);
            GMbehave.TheScrip.EggChange(false);
        }
    }
}
