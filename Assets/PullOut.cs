using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullOut : MonoBehaviour
{
    public bool Active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Active = !Active;
        Acceration = 0;
    }

    float Acceration = 0;

    private void FixedUpdate()
    {
        if (Active)
        {
            if (transform.localPosition.x >= -5.75f)
            {
                transform.localPosition = new Vector2(-5.75f, 0);
                Acceration = 0;
            } else
            {
                transform.localPosition = new Vector2(transform.localPosition.x + Acceration, 0);
                Acceration += .05f;
            }
        } else
        {
            if (transform.localPosition.x <= -11.5f)
            {
                transform.localPosition = new Vector2(-11.5f, 0);
                Acceration = 0;
            }
            else
            {
                transform.localPosition = new Vector2(transform.localPosition.x - Acceration, 0);
                Acceration += .05f;
            }
        }
    }
}
