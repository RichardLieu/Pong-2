using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBiggerPaddle : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.OnLBiggerPaddle(this);
    }
}
