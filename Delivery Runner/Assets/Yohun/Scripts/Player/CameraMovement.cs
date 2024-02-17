using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraMovement : MonoBehaviour 
{
    // public static CameraMovement Instance;
    [SerializeField] private GameObject girlCharPlayer;
    [SerializeField] private GameObject boyCharPlayer;
	private GameObject player;
	public Vector3 offset;
    private Vector3 velocity;
    private Vector3 newPosForSmoothing;
    private Transform thisTransform;

    [SerializeField] private float smoothTime = 0.3f;

    // private void Awake() => Instance = this;
    private void Awake() 
    {
        thisTransform = transform;
        velocity = new Vector3(0.5f, 0.5f, 0.5f);
    }

	void Start () 
    {
        if (CharacterSelectionController.characterSelected == 1)
        {
            player = girlCharPlayer;
        }
        if (CharacterSelectionController.characterSelected == 2)
        {
            player = boyCharPlayer;
        }
		offset = transform.position - player.transform.position;
	}
	
    void LateUpdate ()
    {
        newPosForSmoothing.x = Mathf.SmoothDamp(thisTransform.position.x, player.transform.position.x + offset.x, ref velocity.x, smoothTime);
        newPosForSmoothing.y = Mathf.SmoothDamp(thisTransform.position.y, player.transform.position.y + offset.y, ref velocity.y, smoothTime);
        newPosForSmoothing.z = player.transform.position.z + offset.z;
        transform.position = Vector3.Slerp(thisTransform.position, newPosForSmoothing, Time.time);
    }

    // private IEnumerator OnShake(float duration, float strength)
    // {
    //     transform.DOShakePosition(duration, strength);
    //     transform.DOShakeRotation(duration, strength);
    //     yield return null; 

    // }

    // public static void Shake(float duration, float strength) => Instance.StartCoroutine(Instance.OnShake(duration, strength));

    public void CameraShake()
    {
        StartCoroutine(Shake(.25f, .1f));
    }

	IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        Debug.Log(originalPos);

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float y = Random.Range(originalPos.y - 1f, originalPos.y + 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x, y, originalPos.z);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
