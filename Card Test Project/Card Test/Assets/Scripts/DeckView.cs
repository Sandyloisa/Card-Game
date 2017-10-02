using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Deck))]
public class DeckView : MonoBehaviour {

	Deck deck;

	public Vector3 start;
	public GameObject cardPrefab;
	public float cardOffset;

	void Start()
	{
		deck = GetComponent<Deck> ();
		ShowCards ();
	}
	void ShowCards()
	{
		int cardCount = 0;

		foreach (int i in deck.GetCards()) {

			float co = cardOffset * cardCount;

			GameObject cardCopy = (GameObject)Instantiate (cardPrefab);
			Vector3 temp = start + new Vector3 (0f, co);
			cardCopy.transform.position = temp;

			CardModel cardModel = cardCopy.GetComponent<CardModel> ();
			cardModel.cardIndex = i;
			cardModel.ToggleFace (true);

			SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer> ();
			spriteRenderer.sortingOrder = 51- cardCount;


			cardCount++;
		}
	}
}
