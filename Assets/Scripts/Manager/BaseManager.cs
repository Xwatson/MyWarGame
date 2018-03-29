using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager {
    protected Game gameFacade;
    public BaseManager(Game game)
    {
        this.gameFacade = game;
    }
	public virtual void OnInit() { }

    public virtual void OnDestroy() { }
}
