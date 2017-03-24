using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game//то, что будем сохранять
{
    public static Game current;
    private int level;//уровень
	private int coin;                 //количество очков
	private int lives;                 //тут еще будут штуки из мета-игры
    public Game()
    {
		level = 0;
		coin = 0;
		lives = 0;
	}
	public int Level {
		set { level= value; }
		get { return level;}
	}
	public int Lives {
		set { lives= value; }
		get { return lives;}
	}
	public int Coin {
		set { coin= value; }
		get { return coin;}
	}
}
