using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    SharkCreate sharkCreate;
    Transform target;
    Transform childTarget;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 offsetX;
    
    [Header("Shake")] 
    [SerializeField] float strength;
    [SerializeField] float duration;
    [SerializeField] int vibrato;
    private void Start()
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
        target = sharkCreate.getSharkPlayer().transform;
        childTarget = sharkCreate.getSharkPlayer().transform.GetChild(0).gameObject.transform;
        childTarget.GetComponent<SharkSwim>().OnDamage += CameraShake;
    }
    void FixedUpdate()
    {
        float desiredPosX = childTarget.position.x;
        desiredPosX = Mathf.Clamp(desiredPosX, -1f, 1f);

        float desiredPosZ = target.position.z + offset.z;

        Vector3 desiredPosition = new Vector3(desiredPosX, offset.y, desiredPosZ);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        LookAt(target);
    }

    void LookAt(Transform target)
    {
        var lookPos = target.position - transform.position;
        lookPos.x = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1);
    }

    void CameraShake()
    {
        transform.DOShakePosition(duration,strength,vibrato);
    }
}
