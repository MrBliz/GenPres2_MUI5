module MaterialUI.Menu

open Fable.Core.JsInterop
open Feliz

let materialMenu: obj = importDefault "@mui/material/Menu"

type MaterialMenu =
     static member inline variant (s : string) = prop.custom("variant" , s)
     static member inline create (props: IReactProperty list) =
        Interop.reactApi.createElement(materialMenu, createObj !!props)