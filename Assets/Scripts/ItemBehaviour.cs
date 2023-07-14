using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem ParticleSystem;
    [SerializeField] MeshRenderer Renderer;
    [SerializeField] BoxCollider Collider;

    private void OnTriggerEnter(Collider col)
    {
        StartCoroutine(StartDestruction());
    }

    IEnumerator StartDestruction()
    {
        Renderer.enabled = false;
        Collider.enabled = false;
        ParticleSystem.Play();
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
