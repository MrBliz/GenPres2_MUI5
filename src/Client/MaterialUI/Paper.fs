module MaterialUI.Paper

open Fable.Core.JsInterop
open Feliz
open Microsoft.FSharp.Core

let  materialPaper: obj = importDefault "@mui/material/Paper"

type MaterialPaper =

    static member inline square(b: bool) = prop.custom("square", b)
    static member inline sx (s: (string * obj) list) = prop.custom("sx", createObj s)
    static member inline variant (s : string) = prop.custom("variant" , s)
    static member inline elevation (i : int) = prop.custom("elevation" , i)
    static member inline create (props:  IReactProperty list) =
       Interop.reactApi.createElement(materialPaper, createObj !!props)