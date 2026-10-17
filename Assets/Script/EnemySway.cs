using UnityEngine;

public class EnemySway : MonoBehaviour
{
    [SerializeField] private float swayAmplitude = 0.4f;
    [SerializeField] private float swayFrequency = 6f;
    private float startX;
    private float swayPhase;
    private bool initialized;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (!initialized)
        {
            swayPhase = Random.Range(0f, Mathf.PI * 2f);
            startX = transform.position.x - Mathf.Sin(Time.time * swayFrequency + swayPhase) * swayAmplitude;
            initialized = true;
        }

        float x = startX + Mathf.Sin(Time.time * swayFrequency + swayPhase) * swayAmplitude;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

    }
}
