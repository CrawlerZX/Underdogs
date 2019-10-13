using UnityEngine;
using UnityEngine.UI;

public class DistanceCalculator : MonoBehaviour
{
    Transform tranform;
    public Transform aimTransform;

    public Text text;

    private int distance;

    // Start is called before the first frame update
    void Start()
    {
        tranform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aimTransform != null && transform != null)
        {
            var p1 = transform.position;
            var p2 = aimTransform.position;

            distance = GetDistance(tranform.position, aimTransform.position);

            if (text != null)
            {
                //text.text = string.Format("Player: ({0}, {1}, {2}) \n", Mathf.RoundToInt(p1.x), Mathf.RoundToInt(p1.y), Mathf.RoundToInt(p1.z));
                //text.text += string.Format("Aim: ({0}, {1}, {2}) \n", Mathf.RoundToInt(p2.x), Mathf.RoundToInt(p2.y), Mathf.RoundToInt(p2.z));

                text.text = "Distância: " + distance;
            }
        }
    }

    public static int GetDistance(Vector3 p1, Vector3 p2)
    {
        Vector3 v = p2 - p1;

        int s1 = Mathf.RoundToInt(Mathf.Pow(v.x, 2));
        int s2 = Mathf.RoundToInt(Mathf.Pow(v.y, 2));
        int s3 = Mathf.RoundToInt(Mathf.Pow(v.z, 2));

        var distance = Mathf.RoundToInt(Mathf.Sqrt(s1 + s2 + s3));

        return distance;
    }
}
