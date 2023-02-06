module MaterialUI.Button

open Fable.Core.JsInterop
open Feliz

let materialButton: obj = importDefault "@mui/material/Button"

type MaterialButton =
    static member inline color (s : string) = prop.custom("color", s)
    static member inline variant (s : string) = prop.custom("variant" , s)
    static member inline fullWidth(b: bool) = prop.custom("fullWidth", b)
    static member inline create (props: IReactProperty list) =
        Interop.reactApi.createElement(materialButton, createObj !!props)
