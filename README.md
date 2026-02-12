# UnityTilemapMask
Works like SpriteMask, but made specifically for **Tilemaps**.

### Preview
![alt text](https://github.com/justcoredev/UnityTilemapMask/blob/main/preview.gif?raw=true)

### How to use

1. Download the [latest version](https://github.com/justcoredev/UnityTilemapMask/releases/tag/2.0).
2. Copy it into your project's **Assets** folder.
3. Add the `TilemapMask` component to the `GameObject` that contains your Tilemap.
4. Press `Generate Mask`.
5. For any `SpriteRenderer` that should only appear inside the mask, set `Mask Interaction` -> `Visible Inside Mask`.
6. Done! :)

### Notes: 
- Make sure your `SpriteRenderers` have a higher `Order in Layer` than the `Tilemap`. Otherwise, they may not appear at all.
- Whenever you modify the Tilemap, you need to regenerate the mask:
- - Use the `Generate Mask` button, or
- - Call `TilemapMask.GenerateMask()` at runtime.
- If you don't want to think about it, just call it once on game start.

### How it works?
- The component iterates through all tiles, puts individual `SpriteMask` objects on their positions, and copies their sprites to use as masks.
This approach is simple and works well in most cases. For really large tilemaps, I guess, object pooling or smth like that could be added to improve perfomance. 

