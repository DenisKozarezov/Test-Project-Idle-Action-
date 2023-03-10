//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Core.ECS.Components.CurrentWheatStacks currentWheatStacks { get { return (Core.ECS.Components.CurrentWheatStacks)GetComponent(GameComponentsLookup.CurrentWheatStacks); } }
    public bool hasCurrentWheatStacks { get { return HasComponent(GameComponentsLookup.CurrentWheatStacks); } }

    public void AddCurrentWheatStacks(byte newValue) {
        var index = GameComponentsLookup.CurrentWheatStacks;
        var component = (Core.ECS.Components.CurrentWheatStacks)CreateComponent(index, typeof(Core.ECS.Components.CurrentWheatStacks));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentWheatStacks(byte newValue) {
        var index = GameComponentsLookup.CurrentWheatStacks;
        var component = (Core.ECS.Components.CurrentWheatStacks)CreateComponent(index, typeof(Core.ECS.Components.CurrentWheatStacks));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentWheatStacks() {
        RemoveComponent(GameComponentsLookup.CurrentWheatStacks);
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

    static Entitas.IMatcher<GameEntity> _matcherCurrentWheatStacks;

    public static Entitas.IMatcher<GameEntity> CurrentWheatStacks {
        get {
            if (_matcherCurrentWheatStacks == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentWheatStacks);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentWheatStacks = matcher;
            }

            return _matcherCurrentWheatStacks;
        }
    }
}
