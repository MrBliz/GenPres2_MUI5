module MaterialUI.Box

open Fable.Core.JsInterop
open Feliz

let  materialBox: obj = importDefault "@mui/material/Box"

//TODO: How to implement a container type ?
type MaterialBox =
     static member inline sx (s: (string * obj) list) = prop.custom("sx", createObj s)
     static member inline create (props:  IReactProperty list) =
       Interop.reactApi.createElement(materialBox, createObj !!props)