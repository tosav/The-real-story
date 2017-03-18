using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game//то, что будем сохранять
{
    public static Game current;
    public int level;//уровень
                     //количество очков
                     //тут еще будут штуки из мета-игры
    public Game()
    {
        level = 0;
    }
}
