# Tower Defense
Create a PC Tower Defense game using Unity and C#.

## Codes
Readable
- Keep each file under 100 lines and single responsibility.

Understandable
- All services are created under the [GameServices](Assets/Scripts/Services/GameServices.cs).

Maintainable
- Keep [controllers](Assets/Scripts/Controllers) write data, and [UI](Assets/Scripts/UI) only reads data.
- Game-related configurations implemented by [ScriptableObjects](Assets/Scripts/ScriptableObjects).
- Split [CollisionDetector](Assets/Scripts/Physics) for other objects are easy to apply.

Extendable
- All unit [behaviors](Assets/Scripts/Behaviours) are split into different parts. (favor composition over inheritance)

Testable
- Don't use the Singleton pattern, use the [ServiceLocator](Assets/Pro%20Standard%20Assets/Library/Service) pattern instead of, letting the classes lifecycle can be controlled.

Performance
- [Object pool mechanic](Assets/Scripts/ObjectPools) to reduce unnecessary Instantiate/Destroy.

## Implementations
- A gameplay [scene](Assets/Scene)
- Simple [map](Assets/Resources/Map) with 2D Tilemap system and Tower Defense Pack.
- Simple [state flows](Assets/Scripts/States): InitializeState, ResetState, IdleState, OverState.
- Simple [game configurations](Assets/Resources/Asset): Tower, Enemy, Wave, Map, Player.
- Simple [tower placing mechanic](Assets/Scripts/UI/TowerPlacing.cs) with visual assistance.
- Simple [game over script](Assets/Scripts/UI/GameResultUI.cs)

## Assumptions
- You are using the 1920x1080 or any 16:9 aspect device, it’s not a good experience for the 16:10 aspect.
- You will see enemies appear in the top left of the screen and disappear on the right side of the screen.
- You will see the player's HP on the top left corner of the screen. When enemies reach the right side of the screen, enemies will reduce the player's HP.
- You will see the current wave on the top left corner of the screen. The current wave will increase when all enemies are dead, and there are no more enemies.
- You can click the tower icon on the right side of the panel, then place the tower in the space except for the road.
- You can see the tower turn in direction and attack when enemies enter the tower range.
- You can see enemies disappear when the tower kills them.

## Self-made Library
[Library](Assets/Pro%20Standard%20Assets/Library) for every kind of game used.

## Internal Packages
2D Sprite\
2D Tilemap Editor

## External Packages
[Tower Defense (top-down) Pack](https://opengameart.org/content/tower-defense-300-tilessprites)\
[UniRx](https://assetstore.unity.com/packages/tools/integration/unirx-reactive-extensions-for-unity-17276)
