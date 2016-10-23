using UnityEngine;
using System.Collections;

public class Graph1 : MonoBehaviour
{
    int GRID_POINTS = 100;
    private ParticleSystem.Particle[] points;
    int i = 0;
    float gridPowerTwo;
    bool doOnce;
    

    // Use this for initialization
    void Start ()
    {
        gridPowerTwo = Mathf.Pow(GRID_POINTS, 2);
        doOnce = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!doOnce)
        {
            CreatePoints();

        }

        this.GetComponent<ParticleSystem>().SetParticles(points, points.Length);

    }

    //Having given information about X and Z and calculated for Y value based on X and Z,
    //I created a function to creat points based on given values of X, Y and Z.
    public void CreatePoints()
    {
        doOnce = true;
        points = new ParticleSystem.Particle[(int)gridPowerTwo];

        float[,] dataY = new float[GRID_POINTS, GRID_POINTS];

        for (int x = 0; x < GRID_POINTS; x++)
        {
            for (int z = 0; z < GRID_POINTS; z++)
            {
                dataY[x, z] = -((x - GRID_POINTS / 2) * (x - GRID_POINTS / 2) + (z - GRID_POINTS / 2) * (z - GRID_POINTS / 2)) / 500f + 10f;
                Vector3 pose = new Vector3(x ,dataY[x,z] , z);
                points[i].position = pose;
                points[i++].size = 0.1f;

            }
        }        
    }   
}
