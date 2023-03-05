//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Core.ECS.Components.AnimatorComponent animator { get { return (Core.ECS.Components.AnimatorComponent)GetComponent(GameComponentsLookup.Animator); } }
    public bool hasAnimator { get { return HasComponent(GameComponentsLookup.Animator); } }

    public void AddAnimator(UnityEngine.Animator newValue) {
        var index = GameComponentsLookup.Animator;
        var component = (Core.ECS.Components.AnimatorComponent)CreateComponent(index, typeof(Core.ECS.Components.AnimatorComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnimator(UnityEngine.Animator newValue) {
        var index = GameComponentsLookup.Animator;
        var component = (Core.ECS.Components.AnimatorComponent)CreateComponent(index, typeof(Core.ECS.Components.AnimatorComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnimator() {
        RemoveComponent(GameComponentsLookup.Animator);
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

    static Entitas.IMatcher<GameEntity> _matcherAnimator;

    public static Entitas.IMatcher<GameEntity> Animator {
        get {
            if (_matcherAnimator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Animator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimator = matcher;
            }

            return _matcherAnimator;
        }
    }
}