using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour 
{
	public GameObject player;
	public Vector3 offset;
    private Vector3 velocity;
    private Vector3 newPosForSmoothing;
    private Transform thisTransform;

    [SerializeField] private float smoothTime = 0.3f;

    void Awake ()
    {
        thisTransform = transform;
        velocity = new Vector3(0.5f, 0.5f, 0.5f);
    }

	void Start () 
    {
		offset = transform.position - player.transform.position;
	}
	
    void LateUpdate ()
    {
        newPosForSmoothing.x = Mathf.SmoothDamp(thisTransform.position.x, player.transform.position.x + offset.x, ref velocity.x, smoothTime);
        newPosForSmoothing.y = Mathf.SmoothDamp(thisTransform.position.y, player.transform.position.y + offset.y, ref velocity.y, smoothTime);
        newPosForSmoothing.z = player.transform.position.z + offset.z;
        transform.position = Vector3.Slerp(thisTransform.position, newPosForSmoothing, Time.time);
    }

    public void CameraShake()
    {
        StartCoroutine(Shake(.25f, .1f));
    }

	IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
