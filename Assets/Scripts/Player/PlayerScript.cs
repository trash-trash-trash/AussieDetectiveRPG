using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	Rigidbody2D rb;

	private bool isMoving;
	private bool shoesEquipped = false;
	private Vector2 input;
	private Character character;

	// Start is called before the first frame update
	void Start()
	{
		character = GetComponent<Character>();
		rb = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	public void HandleUpdate()
	{
		if (!character.IsMoving)
		{
			input.x = Input.GetAxisRaw("Horizontal");
			input.y = Input.GetAxisRaw("Vertical");

			//remove diagonal movement
			if (input.x != 0) input.y = 0;

			if (input != Vector2.zero)
			{
				StartCoroutine(character.Move(input));
			}
		}

		character.HandleUpdate();

		if (Input.GetKeyDown(KeyCode.E)) {
			StartCoroutine(Interact());
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			EquipShoes();
		}

	}

	private void EquipShoes()
	{
		shoesEquipped = !shoesEquipped;

		if (shoesEquipped) { 
			print("You put on your shoes!");
			character.ChangeSpeed(+3.7f);
		}
		else{
			print("You took your shoes off!");
			character.ChangeSpeed(-3.7f);
		}

	}

	
	

    IEnumerator Interact()
	{
		Debug.Log("Detective attempted to interact with object/NPC.");
		var facingDir = new Vector3(character.Animator.MoveX, character.Animator.MoveY);
		var interactPos = transform.position + facingDir;

		//Debug.DrawLine(transform.position, interactPos, Color.red, 5f);

		var collider = Physics2D.OverlapCircle(interactPos, 0.5f, GameLayers.i.InteractableLayer);
		if(collider != null)
		{
			yield return collider.GetComponent<Interactable>()?.Interact(transform);
			Debug.Log("Detective successefully interacted with Object/NPC");
		}
	}


}
