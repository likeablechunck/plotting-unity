using UnityEngine;
using System.Collections;

public class Graph1 : MonoBehaviour
{
    int GRID_POINTS = 100;
    //public ParticleSystem my_Particle;
    private ParticleSystem.Particle[] points;

    // Use this for initialization
    void Start ()
    {
        //my_Particle = new ParticleSystem();
        points = new ParticleSystem.Particle[GRID_POINTS];

        float[,] dataY = new float[GRID_POINTS, GRID_POINTS];
        for (int x = 0; x < GRID_POINTS; x++)
        {
            for (int z = 0; z < GRID_POINTS; z++)
            {
                // dataY [x, z] = (Mathf.Sin (x/10f) + 1) * (Mathf.Sin(z/10f) + 1);
                dataY[x, z] = -((x - GRID_POINTS / 2) * (x - GRID_POINTS / 2) + (z - GRID_POINTS / 2) * (z - GRID_POINTS / 2)) / 500f + 10f;

                for (int i = 0; i < GRID_POINTS; i++)
                {
                    points[i].position = new Vector3(x, 0, z);
                    points[i].size = 0.1f;

                }
            }
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        //my_Particle.SetParticles(points, points.Length);       

    }
}
