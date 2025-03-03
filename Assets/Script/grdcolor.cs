using UnityEngine;

public class grdcolor : MonoBehaviour
{
    public Material mat;
    public Color[] c;
    // Start is called before the first frame update
    void Start()
    {
        mat.color = c[Random.Range(0, c.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
