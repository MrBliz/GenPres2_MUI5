module MaterialUi.TextField

open Fable.Core.JsInterop
open Feliz
let  materialTextField: obj = importDefault "@mui/material/TextField"

type MaterialTextField =
     static member inline variant (s : string) = prop.custom("variant", s)
     static member inline inputType (s : string) = prop.custom("type", s)
     static member inline helperText (s : string) = prop.custom("helperText", s)
     static member inline label (s : string) = prop.custom("label", s)
     static member inline size (s : string) = prop.custom("size", s)
     static member inline defaultValue (s : string) = prop.custom("defaultValue", s)
     static member inline margin (s : string) = prop.custom("margin", s)
     static member inline color (s : string) = prop.custom("color", s)
     static member inline fullWidth(b: bool) = prop.custom("fullWidth", b)
     static member inline error(b: bool) = prop.custom("error", b)
     static member inline multiline(b: bool) = prop.custom("multiline", b)
     static member inline focused(b: bool) = Interop.mkAttr "focused"
     //TODO: Input should be an integer
     static member inline maxRows (s: (string * obj) list) = prop.custom("maxRows", createObj s)
     static member inline inputProps (s: (string * obj) list) = prop.custom("inputProps", createObj s)
     static member inline create (props:  IReactProperty list) =
       Interop.reactApi.createElement(materialTextField, createObj !!props)