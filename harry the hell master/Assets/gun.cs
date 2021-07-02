using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletty;

    private float TimeBwtShots;
    public float StartTimeBwtShots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (TimeBwtShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletty, shootPoint.position, transform.rotation);
                TimeBwtShots = StartTimeBwtShots;
            }
        }else
        {
            TimeBwtShots -= Time.deltaTime;
        }
    }
}
