module MaterialUi.Button

open Fable.Core.JsInterop
open Feliz

let  materialButton: obj = importDefault "@mui/material/Button"

type MaterialButton =
     static member inline variant (s : string) = prop.custom("variant" , s)
     static member inline create (props: IReactProperty list) =
        Interop.reactApi.createElement(materialButton, createObj !!props)