using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    public Flash flash;
    public float timeBetweenFlash = 5f;
    private Coroutine _instance = null;

    // Update is called once per frame
    void Update()
    {
        if (_instance == null && Input.GetKeyDown(KeyCode.Space))
        {
            //Start the coroutine we define below named ExampleCoroutine.
            _instance = StartCoroutine(DoFlash());
        }
    }

    IEnumerator DoFlash()
    {
        flash.doCameraFlash = true;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeBetweenFlash);

        StopCoroutine(_instance);
        _instance = null;
    }
}