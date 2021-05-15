using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoSample : MonoBehaviour
{
    public struct vertexLine
    {
        public Vector3 start;
        public Vector3 end;
        public vertexLine(Vector3 a, Vector3 b)
        {
            this.start = a;
            this.end = b;
        }
    }
    public Material material;

    public List<vertexLine> _lineList = new List<vertexLine>();
    // Start is called before the first frame update
    void Start()
    {
        // 가로만
        for(int i=-5;i<=5;i++)
        {
            _lineList.Add(new vertexLine(new Vector3(-5,0,i), new Vector3(5,0,i)));
            _lineList.Add(new vertexLine(new Vector3(i, 0, -5), new Vector3(i, 0, 5)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPostRender()
    {
        material.SetPass(0); //optional, i have mine set to "Sprites-Default"
        //OnPostRender method
        GL.Begin(GL.LINES);
        foreach(var line in _lineList)
        {
            GL.Vertex(line.start);
            GL.Vertex(line.end);
        }
        GL.End();
    }
}
