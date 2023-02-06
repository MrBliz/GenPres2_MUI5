module MaterialUI.FormControl

open Fable.Core.JsInterop
open Feliz

let  materialFormControl: obj = importDefault "@mui/material/FormControl"

type MaterialFormControl =

    static member inline create (props:  IReactProperty list) =
        Interop.reactApi.createElement(materialFormControl, createObj !!props)

    static member inline variant(s : string) = prop.custom("variant", s)

    static member inline fullWidth(b: bool) = prop.custom("fullWidth", b)
    static member inline margin (s : string) = prop.custom("margin", s)

    static member inline size (s : string) = prop.custom("size", s)
     static member inline sx (s: (string * obj) list) = prop.custom("sx", createObj s)
