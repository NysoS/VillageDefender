using UnityEngine;

public class Grid_system : MonoBehaviour
{

    public GameObject node;
    public int size_x, size_y;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        Grid();
    }

    void Grid()
    {
        for (int x = 0; x < size_x; x++)
        {
            for (int y = 0; y < size_y; y++)
            { 
                GameObject n = Instantiate(node, transform.position + new Vector3(x * offset, 0, y * offset), Quaternion.identity);
                n.transform.SetParent(transform);
            }
        }
    }
}
