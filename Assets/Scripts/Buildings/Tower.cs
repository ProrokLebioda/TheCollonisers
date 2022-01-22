using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    private LineRenderer lineRenderer;

    public float radius = 115.0f;
    public GameObject borderPost;

    

    // Start is called before the first frame update
    void Start()
    {
        CalculatePositions();
        InstantiatePoints();

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPositions(positions.ToArray());
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
            Debug.Log("Point no:" + i + " ;X: " + x + " ;Y: " + y + " ;Z: " + z);
        }
    }

    void InstantiatePoints()
    {
        foreach (Vector3 position in positions)
        {
            Instantiate(borderPost, position, new Quaternion()).transform.parent = this.transform;
        }
    }
}
