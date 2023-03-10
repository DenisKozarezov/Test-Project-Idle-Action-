//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Core.ECS.Components.BroughtStacks broughtStacksComponent = new Core.ECS.Components.BroughtStacks();

    public bool isBroughtStacks {
        get { return HasComponent(GameComponentsLookup.BroughtStacks); }
        set {
            if (value != isBroughtStacks) {
                var index = GameComponentsLookup.BroughtStacks;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : broughtStacksComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherBroughtStacks;

    public static Entitas.IMatcher<GameEntity> BroughtStacks {
        get {
            if (_matcherBroughtStacks == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BroughtStacks);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBroughtStacks = matcher;
            }

            return _matcherBroughtStacks;
        }
    }
}