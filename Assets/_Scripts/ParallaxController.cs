using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    float startPos, length;
    [SerializeField] GameObject cam;
    [SerializeField] float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);
        var pos = transform.position;
        transform.position = new Vector3(startPos + distance, pos.y, pos.z);

        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
