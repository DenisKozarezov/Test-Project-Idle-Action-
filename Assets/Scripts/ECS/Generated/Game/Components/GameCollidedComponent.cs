//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Core.ECS.Components.Collided collided { get { return (Core.ECS.Components.Collided)GetComponent(GameComponentsLookup.Collided); } }
    public bool hasCollided { get { return HasComponent(GameComponentsLookup.Collided); } }

    public void AddCollided(int newCollidedID) {
        var index = GameComponentsLookup.Collided;
        var component = (Core.ECS.Components.Collided)CreateComponent(index, typeof(Core.ECS.Components.Collided));
        component.CollidedID = newCollidedID;
        AddComponent(index, component);
    }

    public void ReplaceCollided(int newCollidedID) {
        var index = GameComponentsLookup.Collided;
        var component = (Core.ECS.Components.Collided)CreateComponent(index, typeof(Core.ECS.Components.Collided));
        component.CollidedID = newCollidedID;
        ReplaceComponent(index, component);
    }

    public void RemoveCollided() {
        RemoveComponent(GameComponentsLookup.Collided);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCollided;

    public static Entitas.IMatcher<GameEntity> Collided {
        get {
            if (_matcherCollided == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Collided);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollided = matcher;
            }

            return _matcherCollided;
        }
    }
}