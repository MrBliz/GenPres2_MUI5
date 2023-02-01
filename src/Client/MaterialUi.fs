module MaterialUi

open Fable.Core.JsInterop
open Feliz

let  materialBox: obj = importDefault "@mui/material/Box"


//TODO: How to implement a container type ?
type MaterialBox =
     static member inline sx (s : string) = prop.custom("sx", s)
     static member inline create (props:  ReactElement list) =
       Interop.reactApi.createElement(materialBox, createObj !!props)