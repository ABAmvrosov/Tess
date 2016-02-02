using UnityEngine;
using System.Collections;

public static class XORUtil {

	public static void Highlight (Cell cell, GroundCardFigure groundCardFigure) {
		switch (groundCardFigure) {
		case GroundCardFigure.Cube:
			Cube ();
			break;
		case GroundCardFigure.J:
			J ();
			break;
		case GroundCardFigure.L:
			L ();
			break;
		case GroundCardFigure.S:
			S ();
			break;
		case GroundCardFigure.T:
			T ();
			break;
		case GroundCardFigure.Z:
			Z ();
			break;
		}
	}
	
	public static void UnHighlight(Cell cell, GroundCardFigure groundCardFigure) {
		switch (groundCardFigure) {
		case GroundCardFigure.Cube:
			Cube ();
			break;
		case GroundCardFigure.J:
			J ();
			break;
		case GroundCardFigure.L:
			L ();
			break;
		case GroundCardFigure.S:
			S ();
			break;
		case GroundCardFigure.T:
			T ();
			break;
		case GroundCardFigure.Z:
			Z ();
			break;
		}
		
	}

	public static void Invert (Cell cell, GroundCardFigure groundCardFogure) {
		
	}
	
	static void Cube () {
		
	}
	
	static void J () {
		
	}
	
	static void L () {
		
	}
	
	static void S () {
		
	}
	
	static void T () {
		
	}
	
	static void Z () {
		
	}
	
	static void UnCube () {
		
	}
	
	static void UnJ () {
		
	}
	
	static void UnL () {
		
	}
	
	static void UnS () {
		
	}
	
	static void UnT () {
		
	}
	
	static void UnZ () {
		
	}
}
