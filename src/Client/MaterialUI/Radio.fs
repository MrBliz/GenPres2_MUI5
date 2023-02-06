module MaterialUI.Radio

open Fable.Core.JsInterop
open Feliz
let materialRadio: obj = importDefault "@mui/material/Radio"

type MaterialRadio =
     static member inline size (s : string) = prop.custom("size", s)
     static member inline inputProps (s: (string * obj) list) = prop.custom("inputProps", createObj s)
     static member inline create (props:  IReactProperty list) =
       Interop.reactApi.createElement(materialRadio, createObj !!props)