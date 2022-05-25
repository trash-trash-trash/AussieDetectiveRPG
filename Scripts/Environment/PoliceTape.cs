using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceTape : MonoBehaviour, Interactable
{

	[SerializeField] Sprite cutTape;

	SpriteRenderer spriteRenderer;

	BoxCollider2D collider;

    void Awake()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		collider = this.GetComponent<BoxCollider2D>();
	}
	public IEnumerator Interact(Transform initiator){
		Debug.Log("Okay...");
		yield return spriteRenderer.sprite = cutTape;
		collider.enabled = false;
    }
}
