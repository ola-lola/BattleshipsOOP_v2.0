﻿using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships {
    class Ocean {
    	private Random random = new Random();
	private Square[,] Board = new Square[10,10];
	public Ocean(){
		for(int x = 0; x<10; x++){
			for(int y = 0; y<10; y++){
				Board[x,y] = new Square();
			}
		}
	}
	public void DebugOcean(){
		
		// Console.WriteLine("  |A|B|C|D|E|F|G|H|I|J|");
		Console.WriteLine("  |0|1|2|3|4|5|6|7|8|9|");

		for(int y = 0; y < 10; y++){
			if(y<9){
				// Console.Write(" "+(y+1)+"|");
				Console.Write(" "+(y)+"|");
			} else {
				// Console.Write((y+1)+"|");
				Console.Write(" "+(y)+"|");
			}
			for (int x = 0; x < 10; x++){
				Console.Write(Board[x,y].Draw()+"|");
			}
			Console.WriteLine("");
		}
	}
	public bool DebugPutRandomlyShip(Square.Mark type){
		bool horizontal = false;
		if(random.Next(2)==1){
		  horizontal = true;
		};
		int positionX = random.Next(10);
		int positionY = random.Next(10);
		int initx = positionX;
		int inity = positionY;
		int size = Square.GetOccupiedSquares(type);

		var startX = positionX;
		if (startX > 0) {
			startX--;
		}
		var startY = positionY;
		if (startY > 0) {
			startY--;
		}

		var endX = positionX;
		var endY = positionY;

		if (!horizontal) {
			endY += size-1;
		}
		else {
			endX += size-1;
		}
		// if end point is not the last coordinate check one past it.
		if (endY < 9) {
			endY++;
		}

		if (endX < 9) {
			endX++;
		}

		if (startX < 0 || startY < 0 || endX > 9 || endY > 9) {
			return false;
		} 

		for (int cy = startY; cy <= endY; cy++) {
			for (int cx = startX; cx <= endX; cx++) {
				if(!Board[cx, cy].IsAvailable()) return false;
			}
		}

		if(horizontal){
			for(int cx = initx; cx<size+initx; cx++){
				Board[cx, inity].SetMark(type);
			}
		} else {
			for(int cy = inity; cy<size+inity; cy++){
				Board[initx, cy].SetMark(type);
			}
		}
		return true;
	}
    }
}