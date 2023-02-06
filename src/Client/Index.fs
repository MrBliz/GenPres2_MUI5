module Index

open Elmish
open Fable.Remoting.Client
open Feliz
open MaterialUI.Container
open Shared
open MaterialUI.Button
open MaterialUI.TextField
open MaterialUI.Box
open MaterialUI.AppBar
open MaterialUI.Toolbar
open MaterialUI.IconButton
open MaterialUI.Icons
open MaterialUI.Typography
open MaterialUI.Paper
open MaterialUI.FormGroup
open Components

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

let containerBox (model: Model) (dispatch: Msg -> unit) =

    MaterialPaper.create [
       MaterialPaper.elevation 5
       prop.children[
           Html.ol [
              for todo in model.Todos do
                  Html.li [ prop.text todo.Description ]
           ]
           Html.div [
                prop.children [
                    MaterialFormGroup.create[
                        MaterialFormGroup.row true
                        prop.children [
                            MaterialTextField.create [
                                MaterialTextField.variant "filled"
                                prop.value model.Input
                                prop.placeholder "What needs to be done?"
                                prop.onChange (fun x -> SetInput x |> dispatch)
                                MaterialTextField.margin "normal"
                                MaterialTextField.helperText "Required"
                            ]
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
       ]
    ]


let view (model: Model) (dispatch: Msg -> unit) =
    MaterialContainer.create [
        MaterialContainer.maxWidth false
        MaterialContainer.disableGutters true
        prop.children [
            NavBar.create
            ControlBar.create
            MaterialContainer.create [
                    MaterialContainer.maxWidth "sm"
                    prop.children [
                        //containerBox model dispatch
                    ]
                ]
            BottomNavigation.create
        ]
    ]