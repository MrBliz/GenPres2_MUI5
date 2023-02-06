module MaterialUI.Typography

open Fable.Core.JsInterop
open Feliz

let  materialTypography: obj = importDefault "@mui/material/Typography"

type MaterialTypography =
     static member inline sx (s: (string * obj) list) = prop.custom("sx", createObj s)
     static member inline variant (s : string) = prop.custom("variant" , s)

     static member inline create (props:  IReactProperty list) =
       Interop.reactApi.createElement(materialTypography, createObj !!props)