using UnityEngine;
using System.Collections;

public class Graph1 : MonoBehaviour
{
    //given data
    int GRID_POINTS = 100;
    //creating an array of particles
    private ParticleSystem.Particle[] points;
    //particle index
    int i = 0;
    //how big this points array needs to be?
    //100X100
    float pointsArrayLength;
    //creating the points should happen only ONCE in Update() Function
   
    

    // Use this for initialization
    void Start ()
    {
        pointsArrayLength = Mathf.Pow(GRID_POINTS, 2);
       
        //it is great to use StartCoroutine to do this iteration ONCE only
        //and not inside the Update()
        StartCoroutine("CreatePoints");
      

    }
	
	// Update is called once per frame
	void Update ()
    {
        //access the particleSystem and display the points by using SetParticle 
        this.GetComponent<ParticleSystem>().SetParticles(points, points.Length);

    }

    //Given available information about X and Z and calculated for Y value based on X and Z,
    //I created a function to creat points based on given values of X, Y and Z.
    IEnumerator  CreatePoints()
    {
        //define what is point array       
        points = new ParticleSystem.Particle[(int)pointsArrayLength];

        float[,] dataY = new float[GRID_POINTS, GRID_POINTS];

        for (int x = 0; x < GRID_POINTS; x++)
        {
            for (int z = 0; z < GRID_POINTS; z++)
            {
                dataY[x, z] = -((x - GRID_POINTS / 2) * (x - GRID_POINTS / 2) + (z - GRID_POINTS / 2) * (z - GRID_POINTS / 2)) / 500f + 10f;
                Vector3 pose = new Vector3(x ,dataY[x,z] , z);
                //Now that we have the info regarding x,y,z positions,
                //we can assign it to a specified point position
                points[i].position = pose;
                //point position has been set to 0.1f
                points[i++].size = 0.1f;

            }
        }
        //nothing to be returned
        yield return null;       
    }   
}
