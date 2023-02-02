module Index

open Elmish
open Fable.Remoting.Client
open Shared
open MaterialUi.Button
open MaterialUi.CheckBox
open MaterialUi.Radio
open MaterialUi.TextField
open Fable.Core.JsInterop


type Model = { Todos: Todo list; Input: string }

type Msg =
    | GotTodos of Todo list
    | SetInput of string
    | AddTodo
    | AddedTodo of Todo

let todosApi =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<ITodosApi>

let init () : Model * Cmd<Msg> =
    let model = { Todos = []; Input = "" }

    let cmd = Cmd.OfAsync.perform todosApi.getTodos () GotTodos

    model, cmd

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | GotTodos todos -> { model with Todos = todos }, Cmd.none
    | SetInput value -> { model with Input = value }, Cmd.none
    | AddTodo ->
        let todo = Todo.create model.Input

        let cmd = Cmd.OfAsync.perform todosApi.addTodo todo AddedTodo

        { model with Input = "" }, cmd
    | AddedTodo todo -> { model with Todos = model.Todos @ [ todo ] }, Cmd.none

open Feliz
open Feliz.Bulma

let navBrand =
    Bulma.navbarBrand.div [
        Bulma.navbarItem.a [
            prop.href "https://safe-stack.github.io/"
            navbarItem.isActive
            prop.children [
                Html.img [
                    prop.src "/favicon.png"
                    prop.alt "Logo"
                ]
            ]
        ]
    ]

let containerBox (model: Model) (dispatch: Msg -> unit) =

    Bulma.box [
        Bulma.content [
            Html.ol [
                for todo in model.Todos do
                    Html.li [ prop.text todo.Description ]
            ]
        ]
        Bulma.field.div [
            field.isGrouped
            prop.children [
                Bulma.control.p [
                    control.isExpanded
                    prop.children [
                        MaterialTextField.create [
                            MaterialTextField.variant "filled"
                            prop.value model.Input
                            prop.placeholder "What needs to be done?"
                            prop.onChange (fun x -> SetInput x |> dispatch)
                            MaterialTextField.margin "normal"
                            MaterialTextField.helperText "Required"
                        ]
                        MaterialTextField.create [
                            MaterialTextField.variant "outlined"
                            MaterialTextField.error true
                            MaterialTextField.label "Error"
                            MaterialTextField.helperText "Invalid Value"
                            MaterialTextField.defaultValue "Invalid Text"
                            MaterialTextField.margin "normal"
                        ]
                        MaterialTextField.create [
                            MaterialTextField.variant "standard"
                            MaterialTextField.inputType "number"
                            MaterialTextField.helperText "Required"
                            MaterialTextField.label "Number"
                            MaterialTextField.fullWidth true
                            prop.placeholder "0"
                            MaterialTextField.margin "normal"
                            MaterialTextField.inputProps [ "aria-label", "B" ]
                            //prop.onChange (fun x -> SetInput x |> dispatch)
                        ]

                        MaterialTextField.create [
                            MaterialTextField.variant "filled"
                            MaterialTextField.multiline true
                            MaterialTextField.margin "normal"
                            MaterialTextField.defaultValue "Multiline"

                        ]

                        MaterialTextField.create [
                            MaterialTextField.variant "outlined"
                            MaterialTextField.margin "normal"
                            MaterialTextField.color "secondary"
                            MaterialTextField.focused true
                            MaterialTextField.defaultValue "focused with color"

                        ]
                        MaterialRadio.create[
                             MaterialRadio.size "large"
                             MaterialRadio.inputProps [ "aria-label", "B" ]
                        ]
                        MaterialCheckBox.create[
                             MaterialCheckBox.size "large"
                             MaterialCheckBox.checked true
                        ]
                        MaterialCheckBox.create[
                             MaterialCheckBox.size "large"
                        ]
                        MaterialCheckBox.create[
                             MaterialCheckBox.size "small"
                             prop.disabled true
                             prop.defaultChecked true
                        ]
                    ]
                ]
                Bulma.control.p [
                    MaterialButton.create [
                        MaterialButton.variant "outlined"
                        prop.disabled (Todo.isValid model.Input |> not)
                        prop.onClick (fun _ -> dispatch AddTodo)
                        prop.text "Add"
                    ]
                ]
            ]
        ]
    ]

let view (model: Model) (dispatch: Msg -> unit) =
    Bulma.hero [
        hero.isFullHeight
        color.isPrimary
        prop.style [
            style.backgroundSize "cover"
            style.backgroundImageUrl "https://unsplash.it/1200/900?random"
            style.backgroundPosition "no-repeat center center fixed"
        ]
        prop.children [
            Bulma.heroHead [
                Bulma.navbar [
                    Bulma.container [ navBrand ]
                ]
            ]
            Bulma.heroBody [
                Bulma.container [
                    Bulma.column [
                        column.is6
                        column.isOffset3
                        prop.children [
                            Bulma.title [
                                text.hasTextCentered
                                prop.text "SAFEMATERIAL"
                            ]
                            containerBox model dispatch
                        ]
                    ]
                ]
            ]
        ]
    ]