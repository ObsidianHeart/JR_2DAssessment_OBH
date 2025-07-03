# Unity 2D Platformer Project

##Watch the Project Demo
[![Watch the Project Demo](Assets/Sprites/thumbnail.png)](https://youtu.be/hZu5eNQU0SQ)
## Unity Version
- **Tested with Unity 6000.0.24f1 LTS**  


## Player Controls

### Keyboard
- **Move Left:** `A` or `Left Arrow`
- **Move Right:** `D` or `Right Arrow`
- **Run:** Double-tap and hold `A`/`Left Arrow` or `D`/`Right Arrow`
- **Jump:** `Spacebar`

### On-Screen UI Buttons (for mobile/touch)
- **Left Button:** Move left (double-tap to run)
- **Right Button:** Move right (double-tap to run)
- **Jump Button:** Jump

> UI buttons must be set up in the Unity Editor. Assign the `MoveLeft`, `MoveRight`, and `Jump` methods from the `PlayerMovement` script to the respective button `OnClick()` events.

## Features Implemented
- **Player Movement:** Walk, run (via double-tap), and jump with both keyboard and on-screen controls.
- **Ground Detection:** Prevents jumping while in the air.
- **Character Flip:** Player sprite flips to face movement direction.
- **Collectibles:** Pick up items to increase score.
- **Score System:** UI displays current score; win message appears when all collectibles are gathered.
- **Basic Animation:** Player animations for idle, moving, running, and jumping.
- **Mobile-Friendly UI:** On-screen buttons for movement and jumping.

## Known Issues / Improvements
- **UI Setup:** UIManager script is a placeholder; all UI elements (score, win message, buttons) must be manually set up in the Unity Editor.
- **No Pause/Restart:** Game lacks pause and restart functionality.
- **No Sound Effects:** No audio feedback for actions or collectibles.
- **No Enemy/Obstacle Logic:** Only collectibles are implemented; no hazards or enemies.
- **Limited Input Customization:** Controls are hardcoded; consider adding input remapping.
- **Double-Tap Sensitivity:** Double-tap threshold for running may need tuning for different devices or user preferences.

---
