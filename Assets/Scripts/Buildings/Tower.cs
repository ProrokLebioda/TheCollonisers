using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    private LineRenderer lineRenderer;

    public float radius = 115.0f;
    public GameObject borderPost;

    private List<GameObject> borderPosts = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        CalculatePositions();
        InstantiateBorderPosts();

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] _borderPostsPositions = new Vector3[borderPosts.Count];
        int i = 0;
        foreach(GameObject _borderPost in borderPosts)
        {
            _borderPostsPositions[i++] = _borderPost.transform.position;
        }
        lineRenderer.SetPositions(_borderPostsPositions);
        lineRenderer.positionCount = positions.Count;
        lineRenderer.loop = true;
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
        lineRenderer.useWorldSpace = true;
    }

    void CalculatePositions()
    {
        // Calculate positions for points
        for (int i = 0; i < 18; i++)
        {
            // C# Math.Cos/Sin uses radians
            var radians = (20 * i) * Mathf.PI / 180;
            float x = Mathf.Cos(radians) * radius + this.transform.position.x;
            float y = this.transform.position.y;
            float z = Mathf.Sin(radians) * radius + this.transform.position.z;
            positions.Add(new Vector3(x, y, z));
            //Debug.Log("Point no:" + i + " ;X: " + x + " ;Y: " + y + " ;Z: " + z);
        }
    }

    void InstantiateBorderPosts()
    {
        foreach (Vector3 position in positions)
        {
            GameObject _borderP = Instantiate(borderPost, position, Quaternion.identity);
            _borderP.transform.parent = this.transform;
            borderPosts.Add(_borderP);
        }
    }
}
