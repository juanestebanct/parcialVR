using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{

    public Transform Caldedo;
    public float Speed =10,time;
    // Movement speed in units per second.


    public bool Oppen=false,opening=false;


    // Move to the target end position.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            oppen();
        }
    
       

    }
    public void oppen()
    {
        if (!Oppen)
        {
            if (!opening)
            {

                time = 0;
                StartCoroutine(open());
            }
          
        }
        else
        {
            if (!opening)
            {
                time = 0;

                StartCoroutine(close());
            }
        }
    }
 
    IEnumerator open()
    {
       
      
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 15.705f, 0), Quaternion.Euler(90, 15.705f, 0), time);
        time += Time.deltaTime * Speed;
        yield return new WaitForSeconds(0.01f);
        if (time<=1)
        {
            opening = true;
            StartCoroutine(open());
         

        }
        else
        {
            opening = false;
            Debug.Log("esoo");
            Oppen = true;
        }
    }
    IEnumerator close()
    {
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(90, 15.705f, 0), Quaternion.Euler(0, 15.705f, 0), time);
        time += Time.deltaTime * Speed;
        yield return new WaitForSeconds(0.01f);
        if (time <= 1)
        {
            opening = true;
            StartCoroutine(close());

        }
        else
        {
            opening = false;
            Oppen = false;
        }
    }
    
}
