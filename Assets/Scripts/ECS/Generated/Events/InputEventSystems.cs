//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputEventSystems : Feature {

    public InputEventSystems(Contexts contexts) {
        Add(new AnyStoppedDraggingEventSystem(contexts)); // priority: 0
        Add(new InputAnyTouchClickEventSystem(contexts)); // priority: 0
    }
}
