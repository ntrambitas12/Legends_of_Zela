public enum SpriteAction
{
    //for sprites that don't need to change direction it's pointing
    still = 0,
    attack = 1,
    damage = 2,
    use = 3,
    
    //for sprites that can change how they're pointing in all 4 directions
    moveLeft = 0,
    moveRight = 1,
    moveUp = 2,
    moveDown = 3,
    attackLeft = 4,
    attackRight = 5,
    attackUp = 6,
    attackDown = 7,
    damageLeft = 8,
    damageRight = 9,
    damageUp = 10,
    damageDown = 11,
    useLeft = 12,
    useRight = 13, 
    useUp = 14,
    useDown = 15,

    // For bomb
    bombCloud = 4,

    //doors
    doorOpen=0,
    doorClosed = 1,
}