using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU_LoadCarrier : MonoBehaviour
{
    Shader myShader;
    public ComputeShader shade;
    


    void Start()
    {
        myShader = GetComponent<Shader>();
       // shade.SetVector(Shader.PropertyToID("res"), new Vector4(0,0,0,0));
        
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RunShader();

        }
    }

    void RunShader()
    {
        /*List<float> pos = new List<float>(); // has to be an array??
        for (int i = 0; i < 100; i++)
        {
            pos.Add(0);
        }

        var buffer = new ComputeBuffer(pos.Count,sizeof(float));
        buffer.SetData(pos);

        shade.SetBuffer(0, "vec", buffer);
        shade.Dispatch(0, 100, 1, 1); // execute

        buffer.GetData(pos.ToArray());

        buffer.Release(); //

        Debug.Log(pos[100]);*/

        float []index = { 1};
        var buffer = new ComputeBuffer(1, sizeof(float));
        int kernel = shade.FindKernel("CSMain");

        shade.SetBuffer(kernel, "res", buffer);
        buffer.SetData(index);

        shade.Dispatch(kernel, 100, 1, 1); // execute
        buffer.GetData(index);
        buffer.Release();
        Debug.Log(index[0]);
    }
}
