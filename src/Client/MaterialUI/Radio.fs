module MaterialUi.Radio

open Fable.Core.JsInterop
open Feliz
let materialRadio: obj = importDefault "@mui/material/Radio"

type MaterialRadio =
     static member inline size (s : string) = prop.custom("size", s)
     //TODO: How to pass in an object of input props https://mui.com/material-ui/react-radio-button/#size
     static member inline inputProps (s: (string * obj) list) = prop.custom("inputProps", createObj s)
     static member inline create (props:  IReactProperty list) =
       Interop.reactApi.createElement(materialRadio, createObj !!props)