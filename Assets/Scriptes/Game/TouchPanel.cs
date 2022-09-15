using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour,IDragHandler,IBeginDragHandler{

	public PlayerController player;
	bool DragIsStarted=false;


	public void OnDrag(PointerEventData ped){
		if (DragIsStarted) {
			if (!player.DirChange) {
				if (Mathf.Abs (ped.delta.x) > Mathf.Abs (ped.delta.y)) {
					if (ped.delta.x > 2) {
						player.dir = Vector2.right;
						if (!player.Auto)
							player.Move ();
						DragIsStarted = false;
					} else if (ped.delta.x < -2) {
						player.dir = Vector2.left;
						if (!player.Auto)
							player.Move ();
						DragIsStarted = false;
					}
				}

				if (Mathf.Abs (ped.delta.y) > Mathf.Abs (ped.delta.x)) {
					if (ped.delta.y > 2) {
						player.dir = Vector2.up;
						if (!player.Auto)
							player.Move ();
						DragIsStarted = false;
					} else if (ped.delta.y < -2) {
						player.dir = Vector2.down;
						if (!player.Auto)
							player.Move ();
						DragIsStarted = false;
					}
				}
			}
		}
	}

	public void OnBeginDrag(PointerEventData ped){
		DragIsStarted = true;
	}
}
