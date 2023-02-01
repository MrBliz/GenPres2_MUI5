module MaterialUi.CheckBox

open Fable.Core.JsInterop
open Feliz

let materialCheckBox : obj = importDefault "@mui/material/Checkbox"

type MaterialCheckBox =
     static member inline checked(b: bool) = prop.custom("checked", b)
     static member inline size (s : string) = prop.custom("size", s)
     static member inline create (props:  IReactProperty list) =
       Interop.reactApi.createElement(materialCheckBox, createObj !!props)