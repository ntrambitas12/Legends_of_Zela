using System;
using System.Collections.Generic;

interface ILevelLoader{
    public void Add(List<String> characters, List<String> obstacles, List<String> items, List<IController> controllers) {
    /* add a new level to the levelloader. A level will include all the types of sprites.
     * Add will iterate throught the list, call the sprite factory, instantiate the correct sprite, 
     * and add it to the level
     */
    
    }
    public void Update() {
    // method that will update current state of the level/game. This includes updating the controllers and all sprites in the game
    }
    public void Draw() { 
    // method that will draw current state of the level/game
    }
}
