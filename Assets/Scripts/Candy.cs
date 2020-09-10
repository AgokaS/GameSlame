using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private int MasCandy = 4;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {          
            var cn = collider.gameObject.GetComponent<Controller>();
            cn.Step += MasCandy;
            cn.WriteStep();
            Destroy(this.gameObject);
        }
    }

}
