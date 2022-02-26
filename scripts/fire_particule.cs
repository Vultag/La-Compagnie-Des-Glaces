using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_particule : MonoBehaviour
{

    public Vector3 project_direction;
    public Vector3 project_direction_dispersion;

    private float TimeToLive = 1f;
    private float TimeWhenDestroy;


    public void _setup(Vector3 project_dir)
    {

        project_direction = -project_dir; // en - !!
        project_direction_dispersion = new Vector3(Random.Range(-0.12f, 0.12f), Random.Range(-0.12f, 0.12f), Random.Range(-0.12f, 0.12f));

    }


    void Start()
    {

        TimeWhenDestroy = Time.time + TimeToLive;

        //print(TimeWhenDestroy);

    }


    void FixedUpdate()
    {

        //print(Time.time);

        float project_speed = 0.1f;
        this.transform.position += (project_direction + project_direction_dispersion) * project_speed;

        if (Time.time >= TimeWhenDestroy)
        {
            //print("test");
            Destroy(this.gameObject);
        }

    }
}
