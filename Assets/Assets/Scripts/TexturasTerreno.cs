using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturasTerreno : MonoBehaviour {

    public static TexturasTerreno Instance;

    /// <summary>
    /// A single paint decal to instantiate
    /// </summary>
    public Transform PaintPrefab;

    private Renderer rend;

   // public Sprite PaintPrefab;

    private int MinSplashs = 5;
    private int MaxSplashs = 15;
    private float SplashRange = 2f;

    private float MinScale = 0.25f;
    private float MaxScale = 2.5f;

    // DEBUG
    private bool mDrawDebug;
    private Vector3 mHitPoint;
    private List<Ray> mRaysDebug = new List<Ray>();

    void Awake()
    {
        if (Instance != null) Debug.LogError("More than one Painter has been instanciated in this scene!");
        Instance = this;

        if (PaintPrefab == null) Debug.LogError("Missing Paint decal prefab!");
    }

    public void Pintar(Vector3 tamaño, Vector3 posicion)
    {
        // Check for a click
        /*if (Input.GetMouseButtonDown(0))
        {*/
            // Raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
            // Paint!
            // Step back a little for a better effect (that's what "normal * x" is for)
            Paint(hit.point + hit.normal * (SplashRange / 4f), tamaño, posicion);
           
            }
       // }
    }

    public void Paint(Vector3 location, Vector3 tamaño, Vector3 posicion)
    {
        //DEBUG
        mHitPoint = location;
        mRaysDebug.Clear();
        mDrawDebug = true;

        //int n = -1;

        //int drops = Random.Range(MinSplashs, MaxSplashs);
        RaycastHit hit;

        // Generate multiple decals in once
        /*while (n <= drops)
        {
            n++;*/

        // Get a random direction (beween -n and n for each vector component)
        //  var fwd = transform.TransformDirection(Random.onUnitSphere * SplashRange);
        Vector3 fwd = transform.TransformDirection(-Vector3.up);

            mRaysDebug.Add(new Ray(location, fwd));
            // Raycast around the position to splash everwhere we can
            if (Physics.Raycast(location, fwd, out hit, SplashRange))
            {
                if (hit.collider.gameObject.tag == "Terrain")
                {
                    // Create a splash if we found a surface
                    var paintSplatter = GameObject.Instantiate(PaintPrefab,
                                                               new Vector3(posicion.x, hit.point.y, posicion.z) + new Vector3(0, 0.05f, 0),
                                                               // Rotation from the original sprite to the normal
                                                               // Prefab are currently oriented to z+ so we use the opposite
                                                               Quaternion.FromToRotation(Vector3.back, hit.normal)
                                                               ) as Transform;
                    paintSplatter.Rotate(-90, 0, 0);
                    // Random scale
                    //var scaler = tamaño;//Random.Range(MinScale, MaxScale);

                    /*paintSplatter.localScale = new Vector3(
                        paintSplatter.localScale.x * scaler,
                        paintSplatter.localScale.y * scaler,
                        paintSplatter.localScale.z
                    );*/
                    paintSplatter.localScale = tamaño;

                    rend = paintSplatter.GetComponent<Renderer>();

                    rend.material.mainTextureScale = new Vector2(5,5);


                    /* // Random rotation effect
                     var rater = Random.Range(0, 359);
                     paintSplatter.transform.RotateAround(hit.point, hit.normal, rater);


                     // TODO: What do we do here? We kill them after some sec?
                     Destroy(paintSplatter.gameObject, 25);*/
                }
            }
        //}
    }

    void OnDrawGizmos()
    {
        // DEBUG
        if (mDrawDebug)
        {
            Gizmos.DrawSphere(mHitPoint, 0.2f);
            foreach (var r in mRaysDebug)
            {
                Gizmos.DrawRay(r);
            }
        }
    }


}
